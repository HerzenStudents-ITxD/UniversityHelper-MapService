using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Data.Interfaces;

[AutoInject]
public interface IPointLabelRepository
{
  Task CreateAsync(DbPointLabel dbPointLabel);
  Task<DbPointLabel> GetAsync(Guid labelId);
  Task<List<DbPointLabel>> FindAllAsync(GetPointLabelsFilter filter);
  Task<bool> DoesExistAsync(Guid labelId);
  Task<bool> EditStatusAsync(Guid labelId, bool isActive);
  Task UpdateAsync(DbPointLabel dbPointLabel);
}