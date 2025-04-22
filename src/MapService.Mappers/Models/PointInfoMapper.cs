using System.Linq;
using UniversityHelper.MapService.Mappers.Models.Interfaces;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Models;
using System.Text.Json;

namespace UniversityHelper.MapService.Mappers.Models;

public class PointInfoMapper : IPointInfoMapper
{
  public PointInfo Map(DbPoint dbPoint)
  {
    if (dbPoint == null)
    {
      return null;
    }

    return new PointInfo
    {
      Id = dbPoint.Id,
      CreatedBy = dbPoint.CreatedBy,
      CreatedAtUtc = dbPoint.CreatedAtUtc,
      IsActive = dbPoint.IsActive,
      Name = JsonSerializer.Deserialize<Dictionary<string, string>>(dbPoint.Name),
      Description = string.IsNullOrEmpty(dbPoint.Description)
            ? null
            : JsonSerializer.Deserialize<Dictionary<string, string>>(dbPoint.Description),
      Fact = string.IsNullOrEmpty(dbPoint.Fact)
            ? null
            : JsonSerializer.Deserialize<Dictionary<string, string>>(dbPoint.Fact),
      X = dbPoint.X,
      Y = dbPoint.Y,
      Z = dbPoint.Z,
      Icon = dbPoint.Icon,
      Labels = dbPoint.Labels?.Select(l => new PointLabelInfo
      {
        Id = l.Id,
        RoleId = l.LabelId,
        Name = JsonSerializer.Deserialize<Dictionary<string, string>>(l.Label.Name),
        Locale = l.Label.Name, // Assuming Name contains locale key
        CreatedBy = l.CreatedBy,
        CreatedAtUtc = l.CreatedAtUtc,
        IsActive = l.IsActive
      }).ToList() ?? new List<PointLabelInfo>(),
      Photos = dbPoint.Photos?.Select(p => new PointPhotoInfo
      {
        Id = p.Id,
        PhotoId = p.Id,
        Number = p.OrdinalNumber,
        IsActive = p.IsActive
      }).ToList() ?? new List<PointPhotoInfo>(),
      PointTypes = dbPoint.PointTypes?.Select(pt => new PointTypeInfo
      {
        Id = pt.PointTypeId,
        Icon = pt.PointType.Icon,
        Associations = pt.PointType.Associations?.Select(a => a.Association).ToList() ?? new List<string>()
      }).ToList() ?? new List<PointTypeInfo>()
    };
  }
}