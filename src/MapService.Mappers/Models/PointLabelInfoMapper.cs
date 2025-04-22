using System.Text.Json;
using UniversityHelper.MapService.Mappers.Models.Interfaces;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Models;

namespace UniversityHelper.MapService.Mappers.Models;

public class PointLabelInfoMapper : IPointLabelInfoMapper
{
  public PointLabelInfo Map(DbPointLabel dbPointLabel)
  {
    if (dbPointLabel == null)
    {
      return null;
    }

    return new PointLabelInfo
    {
      Id = dbPointLabel.Id,
      Name = JsonSerializer.Deserialize<Dictionary<string, string>>(dbPointLabel.Name),
      CreatedBy = dbPointLabel.CreatedBy,
      CreatedAtUtc = dbPointLabel.CreatedAtUtc,
      IsActive = dbPointLabel.IsActive
    };
  }
}