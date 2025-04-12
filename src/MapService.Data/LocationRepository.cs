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

public class LocationRepository : ILocationRepository
{
  private readonly IDataProvider _provider;
  //private readonly IHttpContextAccessor _httpContextAccessor;

  public LocationRepository(
    IDataProvider provider//,
                          //IHttpContextAccessor httpContextAccessor
      )
  {
    _provider = provider;
    //_httpContextAccessor = httpContextAccessor;
  }

  public Task CreateAsync(DbPoint dbLocation)
  {
    if (dbLocation is null)
    {
      return null;
    }

    _provider.Locations.Add(dbLocation);
    return _provider.SaveAsync();
  }

  public async Task<DbPoint> GetAsync(GetLocationFilter filter)
  {
    return null;
    //return (await
    //  (from location in _provider.Locations
    //   join addition in _provider.LocationAdditions on location.Id equals addition.Location.Id
    //   join label in _provider.LocationLabels on location.Id equals label.Location.Id
    //   join photo in _provider.LocationPhotos on location.Id equals photo.Location.Id
    //   join position in _provider.LocationUnityPositions on location.Id equals position.LocationId
    //   join objectName in _provider.LocationUnityObjectName on location.Id equals objectName.Location.Id
    //   where location.Id == filter.LocationId
    //     && (addition.Locale == filter.Locale)
    //     && (label.Locale == filter.Locale)
    //   select new
    //   {
    //       Location = location
    //   }).ToListAsync()).AsEnumerable().GroupBy(r => r.Location.Id)
    //   .Select(x =>
    //   {
    //       DbLocation location = x.Select(x => x.Location).FirstOrDefault();
    //       location.Additions = x.Select(x => x.Additions).Where(x => x != null).GroupBy(x => x.Id).Select(x => x.First()).ToList();

    //       return (location, x.Select(x => x.User).Where(u => u is not null && u.IsActive).ToList(), x.Select(x => x.RightLocalization).ToList());
    //   }).FirstOrDefault();
  }

  public Task<bool> DoesExistAsync(Guid locationId)
  {
    return _provider.Locations.AnyAsync(r => r.Id == locationId);
  }

  public async Task<bool> EditStatusAsync(Guid locationId, bool isActive)
  {
    DbPoint location = _provider.Locations.FirstOrDefault(x => x.Id == locationId);

    if (location is null)
    {
      return false;
    }

    _provider.Locations.Update(location);

    location.IsActive = isActive;
    location.CreatedBy = 0;// _httpContextAccessor.HttpContext.GetUserId();

    await _provider.SaveAsync();

    return true;
  }

  public Task<List<DbPoint>> FindAllAsync(FindLocationsFilter filter)
  {
    // TODO
    return new(() => new());
  }
}
