using UniversityHelper.MapService.Mappers.Models.Interfaces;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Models;

namespace UniversityHelper.MapService.Mappers.Models;

public class PointTypeAssociationInfoMapper : IPointTypeAssociationInfoMapper
{
  public PointTypeAssociationInfo Map(DbPointTypeAssociation dbPointTypeAssociation)
  {
    if (dbPointTypeAssociation == null)
    {
      return null;
    }

    return new PointTypeAssociationInfo
    {
      Id = dbPointTypeAssociation.Id,
      PointTypeId = dbPointTypeAssociation.PointTypeId,
      Association = dbPointTypeAssociation.Association,
      CreatedBy = dbPointTypeAssociation.CreatedBy,
      CreatedAtUtc = dbPointTypeAssociation.CreatedAtUtc,
      IsActive = dbPointTypeAssociation.IsActive
    };
  }
}