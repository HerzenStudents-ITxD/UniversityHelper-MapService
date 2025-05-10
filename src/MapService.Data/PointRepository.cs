using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityHelper.Core.Extensions;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Data.Provider;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Data;

public class PointRepository : IPointRepository
{
  private readonly IDataProvider _provider;
  private readonly IHttpContextAccessor _httpContextAccessor;

  public PointRepository(
      IDataProvider provider,
      IHttpContextAccessor httpContextAccessor)
  {
    _provider = provider;
    _httpContextAccessor = httpContextAccessor;
  }

  public async Task CreateAsync(DbPoint dbPoint)
  {
    if (dbPoint == null)
    {
      throw new ArgumentNullException(nameof(dbPoint));
    }

    _provider.Points.Add(dbPoint);
    await _provider.SaveAsync();
  }

  public async Task<DbPoint> GetAsync(GetPointFilter filter)
  {
    return await _provider.Points
        .Include(p => p.Labels).ThenInclude(l => l.Label)
        .Include(p => p.Photos)
        .Include(p => p.PointTypes).ThenInclude(pt => pt.PointType)
        .Include(p => p.Associations)
        .FirstOrDefaultAsync(p => p.Id == filter.PointId && (filter.Locale == null || p.IsActive));
  }

  public async Task<bool> DoesExistAsync(Guid pointId)
  {
    return await _provider.Points.AnyAsync(p => p.Id == pointId);
  }

  public async Task<bool> EditStatusAsync(Guid pointId, bool isActive)
  {
    var point = await _provider.Points.FirstOrDefaultAsync(p => p.Id == pointId);
    if (point == null)
    {
      return false;
    }

    point.IsActive = isActive;
    point.CreatedBy = _httpContextAccessor.HttpContext.GetUserId();
    _provider.Points.Update(point);
    await _provider.SaveAsync();
    return true;
  }

  public async Task<List<DbPoint>> FindAllAsync(FindPointsFilter filter)
  {
    var query = _provider.Points
        .Include(p => p.Labels).ThenInclude(l => l.Label)
        .Include(p => p.Photos)
        .Include(p => p.PointTypes).ThenInclude(pt => pt.PointType)
        .Include(p => p.Associations)
        .AsQueryable();

    if (!filter.IncludeDeactivated.GetValueOrDefault(false))
    {
      query = query.Where(p => p.IsActive);
    }

    if (!string.IsNullOrEmpty(filter.Locale))
    {
      // Фильтрация по локализованным полям (Name, Description) в JSON
      query = query.Where(p => EF.Functions.Contains(p.Name, $"\"{filter.Locale}\"")
                           || EF.Functions.Contains(p.Description, $"\"{filter.Locale}\""));
    }

    if (filter.CreatedBy != Guid.Empty)
    {
      query = query.Where(p => p.CreatedBy == filter.CreatedBy);
    }

    if (!string.IsNullOrEmpty(filter.TypeId))
    {
      query = query.Where(p => p.PointTypes.Any(pt => pt.PointTypeId == Guid.Parse(filter.TypeId)));
    }

    if (filter.Page.HasValue && filter.PageSize.HasValue)
    {
      query = query
          .Skip((filter.Page.Value - 1) * filter.PageSize.Value)
          .Take(filter.PageSize.Value);
    }
    return await query.ToListAsync();
  }

  public async Task UpdateAsync(DbPoint dbPoint)
  {
    if (dbPoint == null)
    {
      throw new ArgumentNullException(nameof(dbPoint));
    }

    _provider.Points.Update(dbPoint);
    await _provider.SaveAsync();
  }
}