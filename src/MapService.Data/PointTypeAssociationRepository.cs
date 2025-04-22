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
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Data;

public class PointTypeAssociationRepository : IPointTypeAssociationRepository
{
  private readonly IDataProvider _provider;
  private readonly IHttpContextAccessor _httpContextAccessor;

  public PointTypeAssociationRepository(
      IDataProvider provider,
      IHttpContextAccessor httpContextAccessor)
  {
    _provider = provider;
    _httpContextAccessor = httpContextAccessor;
  }

  public async Task CreateAsync(DbPointTypeAssociation dbPointTypeAssociation)
  {
    if (dbPointTypeAssociation == null)
    {
      throw new ArgumentNullException(nameof(dbPointTypeAssociation));
    }

    _provider.PointTypeAssociations.Add(dbPointTypeAssociation);
    await _provider.SaveAsync();
  }

  public async Task<DbPointTypeAssociation> GetAsync(Guid associationId)
  {
    return await _provider.PointTypeAssociations
        .FirstOrDefaultAsync(a => a.Id == associationId);
  }

  public async Task<bool> DoesExistAsync(Guid associationId)
  {
    return await _provider.PointTypeAssociations.AnyAsync(a => a.Id == associationId);
  }

  public async Task<bool> DoesExistByNameAndTypeAsync(Guid pointTypeId, string association)
  {
    return await _provider.PointTypeAssociations
        .AnyAsync(a => a.PointTypeId == pointTypeId && a.Association == association);
  }

  public async Task<bool> EditStatusAsync(Guid associationId, bool isActive)
  {
    var association = await _provider.PointTypeAssociations.FirstOrDefaultAsync(a => a.Id == associationId);
    if (association == null)
    {
      return false;
    }

    association.IsActive = isActive;
    association.CreatedBy = _httpContextAccessor.HttpContext.GetUserId();
    _provider.PointTypeAssociations.Update(association);
    await _provider.SaveAsync();
    return true;
  }

  public async Task<List<DbPointTypeAssociation>> FindAllAsync(GetPointTypeAssociationsFilter filter)
  {
    var query = _provider.PointTypeAssociations
        .Where(a => a.PointTypeId == filter.PointTypeId);

    if (!filter.IncludeDeactivated)
    {
      query = query.Where(a => a.IsActive);
    }

    return await query.ToListAsync();
  }

  public async Task UpdateAsync(DbPointTypeAssociation dbPointTypeAssociation)
  {
    if (dbPointTypeAssociation == null)
    {
      throw new ArgumentNullException(nameof(dbPointTypeAssociation));
    }

    _provider.PointTypeAssociations.Update(dbPointTypeAssociation);
    await _provider.SaveAsync();
  }
}