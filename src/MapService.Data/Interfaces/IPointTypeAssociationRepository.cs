using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Data.Interfaces;

[AutoInject]
public interface IPointTypeAssociationRepository
{
  Task CreateAsync(DbPointTypeAssociation dbPointTypeAssociation);
  Task<DbPointTypeAssociation> GetAsync(Guid associationId);
  Task<List<DbPointTypeAssociation>> FindAllAsync(GetPointTypeAssociationsFilter filter);
  Task<bool> DoesExistAsync(Guid associationId);
  Task<bool> DoesExistByNameAndTypeAsync(Guid pointTypeId, string association);
  Task<bool> EditStatusAsync(Guid associationId, bool isActive);
  Task UpdateAsync(DbPointTypeAssociation dbPointTypeAssociation);
}