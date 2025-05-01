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

public class PointLabelRepository : IPointLabelRepository
{
  private readonly IDataProvider _provider;
  private readonly IHttpContextAccessor _httpContextAccessor;

  public PointLabelRepository(
      IDataProvider provider,
      IHttpContextAccessor httpContextAccessor)
  {
    _provider = provider;
    _httpContextAccessor = httpContextAccessor;
  }

  public async Task CreateAsync(DbPointLabel dbPointLabel)
  {
    if (dbPointLabel == null)
    {
      throw new ArgumentNullException(nameof(dbPointLabel));
    }

    _provider.PointLabels.Add(dbPointLabel);
    await _provider.SaveAsync();
  }

  public async Task<DbPointLabel> GetAsync(Guid labelId)
  {
    return await _provider.PointLabels
        .FirstOrDefaultAsync(l => l.Id == labelId);
  }

  public async Task<bool> DoesExistAsync(Guid labelId)
  {
    return await _provider.PointLabels.AnyAsync(l => l.Id == labelId);
  }

  public async Task<bool> EditStatusAsync(Guid labelId, bool isActive)
  {
    var label = await _provider.PointLabels.FirstOrDefaultAsync(l => l.Id == labelId);
    if (label == null)
    {
      return false;
    }

    label.IsActive = isActive;
    label.CreatedBy = _httpContextAccessor.HttpContext.GetUserId();
    _provider.PointLabels.Update(label);
    await _provider.SaveAsync();
    return true;
  }

  public async Task<List<DbPointLabel>> FindAllAsync(GetPointLabelsFilter filter)
  {
    var query = _provider.PointLabels.AsQueryable();

    if (!filter.IncludeDeactivated)
    {
      query = query.Where(l => l.IsActive);
    }

    if (!string.IsNullOrEmpty(filter.Locale))
    {
      query = query.Where(l => EF.Functions.Contains(l.Name, $"\"{filter.Locale}\""));
    }

    return await query.ToListAsync();
  }

  public async Task UpdateAsync(DbPointLabel dbPointLabel)
  {
    if (dbPointLabel == null)
    {
      throw new ArgumentNullException(nameof(dbPointLabel));
    }

    _provider.PointLabels.Update(dbPointLabel);
    await _provider.SaveAsync();
  }
}