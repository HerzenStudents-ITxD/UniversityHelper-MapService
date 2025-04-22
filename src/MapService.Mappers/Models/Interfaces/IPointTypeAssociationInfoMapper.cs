using UniversityHelper.Core.Attributes;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Models;

namespace UniversityHelper.MapService.Mappers.Models.Interfaces;

[AutoInject]
public interface IPointTypeAssociationInfoMapper
{
  PointTypeAssociationInfo Map(DbPointTypeAssociation dbPointTypeAssociation);
}