using System.Text.Json;
using UniversityHelper.MapService.Mappers.Models.Interfaces;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Models;

namespace UniversityHelper.MapService.Mappers.Models;

public class PointTypeInfoMapper : IPointTypeInfoMapper
{
  public PointTypeInfo Map(DbPointType dbPointType)
  {
    if (dbPointType == null)
    {
      return null;
    }

    return new PointTypeInfo
    {
      Id = dbPointType.Id,
      Name = JsonSerializer.Deserialize<Dictionary<string, string>>(dbPointType.Name),
      Icon = dbPointType.Icon,
      Associations = dbPointType.Associations?.Select(a => a.Association).ToList() ?? new List<string>(),
      CreatedBy = dbPointType.CreatedBy,
      CreatedAtUtc = dbPointType.CreatedAtUtc,
      IsActive = dbPointType.IsActive
    };
  }
}