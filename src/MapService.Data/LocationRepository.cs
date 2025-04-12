using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityHelper.Core.Extensions;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Data.Provider;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace UniversityHelper.MapService.Data;

public class PointRepository : IPointRepository
{
  private readonly IDataProvider _provider;
  //private readonly IHttpContextAccessor _httpContextAccessor;

  public PointRepository(
    IDataProvider provider//,
                          //IHttpContextAccessor httpContextAccessor
      )
  {
    _provider = provider;
    //_httpContextAccessor = httpContextAccessor;
  }

  public Task CreateAsync(DbPoint dbPoint)
  {
    if (dbPoint is null)
    {
      return null;
    }

    _provider.Points.Add(dbPoint);
    return _provider.SaveAsync();
  }

  public async Task<DbPoint> GetAsync(GetPointFilter filter)
  {
    return null;
    //return (await
    //  (from point in _provider.Points
    //   join addition in _provider.PointAdditions on point.Id equals addition.Point.Id
    //   join label in _provider.PointLabels on point.Id equals label.Point.Id
    //   join photo in _provider.PointPhotos on point.Id equals photo.Point.Id
    //   join position in _provider.PointUnityPositions on point.Id equals position.PointId
    //   join objectName in _provider.PointUnityObjectName on point.Id equals objectName.Point.Id
    //   where point.Id == filter.PointId
    //     && (addition.Locale == filter.Locale)
    //     && (label.Locale == filter.Locale)
    //   select new
    //   {
    //       Point = point
    //   }).ToListAsync()).AsEnumerable().GroupBy(r => r.Point.Id)
    //   .Select(x =>
    //   {
    //       DbPoint point = x.Select(x => x.Point).FirstOrDefault();
    //       point.Additions = x.Select(x => x.Additions).Where(x => x != null).GroupBy(x => x.Id).Select(x => x.First()).ToList();

    //       return (point, x.Select(x => x.User).Where(u => u is not null && u.IsActive).ToList(), x.Select(x => x.RightLocalization).ToList());
    //   }).FirstOrDefault();
  }

  public Task<bool> DoesExistAsync(Guid pointId)
  {
    return _provider.Points.AnyAsync(r => r.Id == pointId);
  }

  public async Task<bool> EditStatusAsync(Guid pointId, bool isActive)
  {
    DbPoint point = _provider.Points.FirstOrDefault(x => x.Id == pointId);

    if (point is null)
    {
      return false;
    }

    _provider.Points.Update(point);

    point.IsActive = isActive;
    //point.CreatedBy = 0;// _httpContextAccessor.HttpContext.GetUserId();

    await _provider.SaveAsync();

    return true;
  }

  public Task<List<DbPoint>> FindAllAsync(FindPointsFilter filter)
  {
    // TODO
    return new(() => new());
  }
}
