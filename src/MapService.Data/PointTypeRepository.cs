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

public class PointTypeRepository : IPointTypeRepository
{
  private readonly IDataProvider _provider;
  private readonly IHttpContextAccessor _httpContextAccessor;

  public PointTypeRepository(
      IDataProvider provider,
      IHttpContextAccessor httpContextAccessor)
  {
    _provider = provider;
    _httpContextAccessor = httpContextAccessor;
  }

  public async Task CreateAsync(DbPointType dbPointType)
  {
    if (dbPointType == null)
    {
      throw new ArgumentNullException(nameof(dbPointType));
    }

    _provider.PointTypes.Add(dbPointType);
    await _provider.SaveAsync();
  }

  public async Task<DbPointType> GetAsync(Guid typeId)
  {
    return await _provider.PointTypes
        .Include(t => t.Associations)
        .FirstOrDefaultAsync(t => t.Id == typeId);
  }

  public async Task<bool> DoesExistAsync(Guid typeId)
  {
    return await _provider.PointTypes.AnyAsync(t => t.Id == typeId);
  }

  public async Task<bool> DoesExistByIconAsync(string icon)
  {
    return await _provider.PointTypes.AnyAsync(t => t.Icon == icon);
  }

  public async Task<bool> EditStatusAsync(Guid typeId, bool isActive)
  {
    var type = await _provider.PointTypes.FirstOrDefaultAsync(t => t.Id == typeId);
    if (type == null)
    {
      return false;
    }

    type.IsActive = isActive;
    type.CreatedBy = _httpContextAccessor.HttpContext.GetUserId();
    _provider.PointTypes.Update(type);
    await _provider.SaveAsync();
    return true;
  }

  public async Task<List<DbPointType>> FindAllAsync(GetPointTypesFilter filter)
  {
    var query = _provider.PointTypes
        .Include(t => t.Associations)
        .AsQueryable();

    if (!filter.IncludeDeactivated)
    {
      query = query.Where(t => t.IsActive);
    }

    if (!string.IsNullOrEmpty(filter.Locale))
    {
      query = query.Where(t => EF.Functions.Contains(t.Name, $"\"{filter.Locale}\""));
    }

    return await query.ToListAsync();
  }

  public async Task UpdateAsync(DbPointType dbPointType)
  {
    if (dbPointType == null)
    {
      throw new ArgumentNullException(nameof(dbPointType));
    }

    _provider.PointTypes.Update(dbPointType);
    await _provider.SaveAsync();
  }
}