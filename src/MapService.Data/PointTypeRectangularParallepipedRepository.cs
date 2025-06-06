﻿using Microsoft.AspNetCore.Http;
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

public class PointTypeRectangularParallepipedRepository : IPointTypeRectangularParallepipedRepository
{
  private readonly IDataProvider _provider;
  private readonly IHttpContextAccessor _httpContextAccessor;

  public PointTypeRectangularParallepipedRepository(
      IDataProvider provider,
      IHttpContextAccessor httpContextAccessor)
  {
    _provider = provider;
    _httpContextAccessor = httpContextAccessor;
  }

  public async Task CreateAsync(DbPointTypeRectangularParallelepiped dbParallelepiped)
  {
    if (dbParallelepiped == null)
    {
      throw new ArgumentNullException(nameof(dbParallelepiped));
    }

    _provider.PointTypeRectangularParallelepipeds.Add(dbParallelepiped);
    await _provider.SaveAsync();
  }

  public async Task<DbPointTypeRectangularParallelepiped> GetAsync(Guid parallelepipedId)
  {
    return await _provider.PointTypeRectangularParallelepipeds
        .FirstOrDefaultAsync(p => p.Id == parallelepipedId);
  }

  public async Task<bool> DoesExistAsync(Guid parallelepipedId)
  {
    return await _provider.PointTypeRectangularParallelepipeds.AnyAsync(p => p.Id == parallelepipedId);
  }

  public async Task<bool> EditStatusAsync(Guid parallelepipedId, bool isActive)
  {
    var parallelepiped = await _provider.PointTypeRectangularParallelepipeds.FirstOrDefaultAsync(p => p.Id == parallelepipedId);
    if (parallelepiped == null)
    {
      return false;
    }

    parallelepiped.IsActive = isActive;
    parallelepiped.CreatedBy = _httpContextAccessor.HttpContext.GetUserId();
    _provider.PointTypeRectangularParallelepipeds.Update(parallelepiped);
    await _provider.SaveAsync();
    return true;
  }

  public async Task<List<DbPointTypeRectangularParallelepiped>> FindAllAsync(GetPointTypeRectangularParallepipedsFilter filter)
  {
    var query = _provider.PointTypeRectangularParallelepipeds
        .Where(p => p.PointTypeId == filter.PointTypeId);

    if (!filter.IncludeDeactivated)
    {
      query = query.Where(p => p.IsActive);
    }

    return await query.ToListAsync();
  }

  public async Task UpdateAsync(DbPointTypeRectangularParallelepiped dbParallelepiped)
  {
    if (dbParallelepiped == null)
    {
      throw new ArgumentNullException(nameof(dbParallelepiped));
    }

    _provider.PointTypeRectangularParallelepipeds.Update(dbParallelepiped);
    await _provider.SaveAsync();
  }
}