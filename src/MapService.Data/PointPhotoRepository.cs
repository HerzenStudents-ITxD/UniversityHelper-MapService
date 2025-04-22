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

public class PointPhotoRepository : IPointPhotoRepository
{
  private readonly IDataProvider _provider;
  private readonly IHttpContextAccessor _httpContextAccessor;

  public PointPhotoRepository(
      IDataProvider provider,
      IHttpContextAccessor httpContextAccessor)
  {
    _provider = provider;
    _httpContextAccessor = httpContextAccessor;
  }

  public async Task CreateAsync(DbPointPhoto dbPointPhoto)
  {
    if (dbPointPhoto == null)
    {
      throw new ArgumentNullException(nameof(dbPointPhoto));
    }

    _provider.PointPhotos.Add(dbPointPhoto);
    await _provider.SaveAsync();
  }

  public async Task<DbPointPhoto> GetAsync(Guid photoId)
  {
    return await _provider.PointPhotos
        .FirstOrDefaultAsync(p => p.Id == photoId);
  }

  public async Task<bool> DoesExistAsync(Guid photoId)
  {
    return await _provider.PointPhotos.AnyAsync(p => p.Id == photoId);
  }

  public async Task<bool> EditStatusAsync(Guid photoId, bool isActive)
  {
    var photo = await _provider.PointPhotos.FirstOrDefaultAsync(p => p.Id == photoId);
    if (photo == null)
    {
      return false;
    }

    photo.IsActive = isActive;
    photo.CreatedBy = _httpContextAccessor.HttpContext.GetUserId();
    _provider.PointPhotos.Update(photo);
    await _provider.SaveAsync();
    return true;
  }

  public async Task<List<DbPointPhoto>> FindAllAsync(GetPointPhotosFilter filter)
  {
    var query = _provider.PointPhotos
        .Where(p => p.PointId == filter.PointId);

    if (!filter.IncludeDeactivated)
    {
      query = query.Where(p => p.IsActive);
    }

    return await query.ToListAsync();
  }

  public async Task UpdateAsync(DbPointPhoto dbPointPhoto)
  {
    if (dbPointPhoto == null)
    {
      throw new ArgumentNullException(nameof(dbPointPhoto));
    }

    _provider.PointPhotos.Update(dbPointPhoto);
    await _provider.SaveAsync();
  }
}