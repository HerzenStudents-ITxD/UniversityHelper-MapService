using System;
using System.Collections.Generic;

namespace UniversityHelper.MapService.Models.Dto.Models;

public record PointInfo
{
  public Guid Id { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public bool IsActive { get; set; }
  public Dictionary<string, string> Name { get; set; } // JSON: {"ru": "Точка 1", "en": "Point 1", "zh": "点 1"}
  public Dictionary<string, string>? Description { get; set; }
  public Dictionary<string, string>? Fact { get; set; }
  public float X { get; set; }
  public float Y { get; set; }
  public float Z { get; set; }
  public string Icon { get; set; }
  public List<PointLabelInfo> Labels { get; set; }
  public List<PointPhotoInfo> Photos { get; set; }
  public List<PointTypeInfo> PointTypes { get; set; }
}