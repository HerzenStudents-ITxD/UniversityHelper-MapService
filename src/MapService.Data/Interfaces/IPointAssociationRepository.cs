using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Data.Interfaces;

[AutoInject]
public interface IPointAssociationRepository
{
  Task CreateAsync(DbPointTypeAssociation dbPointAssociation);
  Task<DbPointTypeAssociation> GetAsync(Guid associationId);
  Task<List<DbPointTypeAssociation>> FindAllAsync(GetPointAssociationsFilter filter);
  Task<bool> DoesExistAsync(Guid associationId);
  Task<bool> DoesExistByNameAsync(string association);
  Task<bool> EditStatusAsync(Guid associationId, bool isActive);
  Task UpdateAsync(DbPointTypeAssociation dbPointAssociation);
}