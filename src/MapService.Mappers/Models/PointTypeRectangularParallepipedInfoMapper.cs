using UniversityHelper.MapService.Mappers.Models.Interfaces;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Models;

namespace UniversityHelper.MapService.Mappers.Models;

public class PointTypeRectangularParallepipedInfoMapper : IPointTypeRectangularParallepipedInfoMapper
{
  public PointTypeRectangularParallepipedInfo Map(DbPointTypeRectangularParallelepiped dbParallelepiped)
  {
    if (dbParallelepiped == null)
    {
      return null;
    }

    return new PointTypeRectangularParallepipedInfo
    {
      Id = dbParallelepiped.Id,
      PointTypeId = dbParallelepiped.PointTypeId,
      XMin = dbParallelepiped.XMin,
      XMax = dbParallelepiped.XMax,
      YMin = dbParallelepiped.YMin,
      YMax = dbParallelepiped.YMax,
      ZMin = dbParallelepiped.ZMin,
      ZMax = dbParallelepiped.ZMax,
      CreatedBy = dbParallelepiped.CreatedBy,
      CreatedAtUtc = dbParallelepiped.CreatedAtUtc,
      IsActive = dbParallelepiped.IsActive
    };
  }
}