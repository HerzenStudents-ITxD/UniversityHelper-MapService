using UniversityHelper.MapService.Mappers.Models.Interfaces;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Models;

namespace UniversityHelper.MapService.Mappers.Models;

public class PointAssociationInfoMapper : IPointAssociationInfoMapper
{
  public PointAssociationInfo Map(DbPointTypeAssociation dbPointAssociation)
  {
    if (dbPointAssociation == null)
    {
      return null;
    }

    return new PointAssociationInfo
    {
      Id = dbPointAssociation.Id,
      Association = dbPointAssociation.Association,
      CreatedBy = dbPointAssociation.CreatedBy,
      CreatedAtUtc = dbPointAssociation.CreatedAtUtc,
      IsActive = dbPointAssociation.IsActive
    };
  }
}