using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.MapService.Models.Db;

namespace UniversityHelper.MapService.Data.Interfaces;

[AutoInject]
public interface IRelationRepository
{
  Task CreateAsync(DbRelation dbRelation);
  Task<DbRelation> GetAsync(Guid relationId);
  Task<bool> DoesExistAsync(Guid relationId);
  Task<bool> DeleteAsync(Guid relationId);
  Task<List<DbRelation>> GetAllAsync();
  Task<List<DbRelation>> GetByPointAsync(Guid pointId);
  Task UpdateAsync(DbRelation dbRelation);
}