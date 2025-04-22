using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityHelper.Core.Extensions;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Data.Provider;
using UniversityHelper.MapService.Models.Db;

namespace UniversityHelper.MapService.Data;

public class RelationRepository : IRelationRepository
{
  private readonly IDataProvider _provider;
  private readonly IHttpContextAccessor _httpContextAccessor;

  public RelationRepository(
      IDataProvider provider,
      IHttpContextAccessor httpContextAccessor)
  {
    _provider = provider;
    _httpContextAccessor = httpContextAccessor;
  }

  public async Task CreateAsync(DbRelation dbRelation)
  {
    if (dbRelation == null)
    {
      throw new ArgumentNullException(nameof(dbRelation));
    }

    _provider.Relations.Add(dbRelation);
    await _provider.SaveAsync();
  }

  public async Task<DbRelation> GetAsync(Guid relationId)
  {
    return await _provider.Relations
        .Include(r => r.FirstPoint)
        .Include(r => r.SecondPoint)
        .FirstOrDefaultAsync(r => r.Id == relationId);
  }

  public async Task<bool> DoesExistAsync(Guid relationId)
  {
    return await _provider.Relations.AnyAsync(r => r.Id == relationId);
  }

  public async Task<bool> DeleteAsync(Guid relationId)
  {
    var relation = await _provider.Relations.FirstOrDefaultAsync(r => r.Id == relationId);
    if (relation == null)
    {
      return false;
    }

    _provider.Relations.Remove(relation);
    await _provider.SaveAsync();
    return true;
  }

  public async Task<List<DbRelation>> GetAllAsync()
  {
    return await _provider.Relations
        .Include(r => r.FirstPoint)
        .Include(r => r.SecondPoint)
        .ToListAsync();
  }

  public async Task<List<DbRelation>> GetByPointAsync(Guid pointId)
  {
    return await _provider.Relations
        .Include(r => r.FirstPoint)
        .Include(r => r.SecondPoint)
        .Where(r => r.FirstPointId == pointId || r.SecondPointId == pointId)
        .ToListAsync();
  }

  public async Task UpdateAsync(DbRelation dbRelation)
  {
    if (dbRelation == null)
    {
      throw new ArgumentNullException(nameof(dbRelation));
    }

    _provider.Relations.Update(dbRelation);
    await _provider.SaveAsync();
  }
}