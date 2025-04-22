using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Data.Interfaces;

[AutoInject]
public interface IPointTypeRectangularParallepipedRepository
{
  Task CreateAsync(DbPointTypeRectangularParallepiped dbParallelepiped);
  Task<DbPointTypeRectangularParallepiped> GetAsync(Guid parallelepipedId);
  Task<List<DbPointTypeRectangularParallepiped>> FindAllAsync(GetPointTypeRectangularParallepipedsFilter filter);
  Task<bool> DoesExistAsync(Guid parallelepipedId);
  Task<bool> EditStatusAsync(Guid parallelepipedId, bool isActive);
  Task UpdateAsync(DbPointTypeRectangularParallepiped dbParallelepiped);
}