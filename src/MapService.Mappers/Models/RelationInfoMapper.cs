using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using UniversityHelper.MapService.Mappers.Models.Interfaces;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Models;

namespace UniversityHelper.MapService.Mappers.Models;

public class RelationInfoMapper : IRelationInfoMapper
{
  public List<PointInfo> Map(List<DbPoint> dbPoints)
  {
    if (dbPoints == null)
    {
      return new List<PointInfo>();
    }

    return dbPoints.Select(p => new PointInfo
    {
      Id = p.Id,
      CreatedBy = p.CreatedBy,
      CreatedAtUtc = p.CreatedAtUtc,
      IsActive = p.IsActive,
      Name = JsonSerializer.Deserialize<Dictionary<string, string>>(p.Name),
      Description = string.IsNullOrEmpty(p.Description)
            ? null
            : JsonSerializer.Deserialize<Dictionary<string, string>>(p.Description),
      Fact = string.IsNullOrEmpty(p.Fact)
            ? null
            : JsonSerializer.Deserialize<Dictionary<string, string>>(p.Fact),
      X = p.X,
      Y = p.Y,
      Z = p.Z,
      Icon = p.Icon,
      Labels = p.Labels?.Select(l => new PointLabelInfo
      {
        Id = l.Id,
        RoleId = l.LabelId,
        Name = JsonSerializer.Deserialize<Dictionary<string, string>>(l.Label.Name),
        Locale = l.Label.Name,
        CreatedBy = l.CreatedBy,
        CreatedAtUtc = l.CreatedAtUtc,
        IsActive = l.IsActive
      }).ToList() ?? new List<PointLabelInfo>(),
      Photos = p.Photos?.Select(ph => new PointPhotoInfo
      {
        Id = ph.Id,
        PhotoId = ph.Id,
        Number = ph.OrdinalNumber,
        IsActive = ph.IsActive
      }).ToList() ?? new List<PointPhotoInfo>(),
      PointTypes = p.PointTypes?.Select(pt => new PointTypeInfo
      {
        Id = pt.PointTypeId,
        Icon = pt.PointType.Icon,
        Associations = pt.PointType.Associations?.Select(a => a.Association).ToList() ?? new List<string>()
      }).ToList() ?? new List<PointTypeInfo>()
    }).ToList();
  }
}