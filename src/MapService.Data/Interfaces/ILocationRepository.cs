using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Data.Interfaces;

[AutoInject]
public interface ILocationRepository
{
  Task CreateAsync(DbPoint dbLocation);

  Task<DbPoint> GetAsync(GetLocationFilter filter);

  Task<List<DbPoint>> FindAllAsync(FindLocationsFilter filter);

  Task<bool> DoesExistAsync(Guid locationId);

  Task<bool> EditStatusAsync(Guid locationId, bool isActive);
}
