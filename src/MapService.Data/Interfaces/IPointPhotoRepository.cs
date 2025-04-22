using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Data.Interfaces;

[AutoInject]
public interface IPointPhotoRepository
{
  Task CreateAsync(DbPointPhoto dbPointPhoto);
  Task<DbPointPhoto> GetAsync(Guid photoId);
  Task<List<DbPointPhoto>> FindAllAsync(GetPointPhotosFilter filter);
  Task<bool> DoesExistAsync(Guid photoId);
  Task<bool> EditStatusAsync(Guid photoId, bool isActive);
  Task UpdateAsync(DbPointPhoto dbPointPhoto);
}