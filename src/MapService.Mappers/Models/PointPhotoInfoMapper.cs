using UniversityHelper.MapService.Mappers.Models.Interfaces;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Models;

namespace UniversityHelper.MapService.Mappers.Models;

public class PointPhotoInfoMapper : IPointPhotoInfoMapper
{
  public PointPhotoInfo Map(DbPointPhoto dbPointPhoto)
  {
    if (dbPointPhoto == null)
    {
      return null;
    }

    return new PointPhotoInfo
    {
      Id = dbPointPhoto.Id,
      PhotoId = dbPointPhoto.Id,
      Number = dbPointPhoto.OrdinalNumber,
      IsActive = dbPointPhoto.IsActive
    };
  }
}