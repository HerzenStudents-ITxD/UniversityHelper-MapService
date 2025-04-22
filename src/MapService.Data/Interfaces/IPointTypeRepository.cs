using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Data.Interfaces;

[AutoInject]
public interface IPointTypeRepository
{
  Task CreateAsync(DbPointType dbPointType);
  Task<DbPointType> GetAsync(Guid typeId);
  Task<List<DbPointType>> FindAllAsync(GetPointTypesFilter filter);
  Task<bool> DoesExistAsync(Guid typeId);
  Task<bool> DoesExistByIconAsync(string icon);
  Task<bool> EditStatusAsync(Guid typeId, bool isActive);
  Task UpdateAsync(DbPointType dbPointType);
}