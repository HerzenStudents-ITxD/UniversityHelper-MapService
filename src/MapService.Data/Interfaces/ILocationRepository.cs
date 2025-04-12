using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Data.Interfaces;

[AutoInject]
public interface IPointRepository
{
  Task CreateAsync(DbPoint dbPoint);

  Task<DbPoint> GetAsync(GetPointFilter filter);

  Task<List<DbPoint>> FindAllAsync(FindPointsFilter filter);

  Task<bool> DoesExistAsync(Guid pointId);

  Task<bool> EditStatusAsync(Guid pointId, bool isActive);
}
