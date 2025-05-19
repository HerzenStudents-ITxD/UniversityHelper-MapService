using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityHelper.MapService.Models.Dto.Requests;

public record CreatePointRequest
{
  [Required]
  public Dictionary<string, string> Name { get; set; } // JSON: {"ru": "Точка 1", "en": "Point 1", "cn": "点 1"}
  public Dictionary<string, string>? Description { get; set; }
  public Dictionary<string, string>? Fact { get; set; }
  [Required]
  public float X { get; set; }
  [Required]
  public float Y { get; set; }
  [Required]
  public float Z { get; set; }
  public string? Icon { get; set; }
  public List<Guid>? LabelIds { get; set; }
  public List<CreatePointPhotoRequest>? Photos { get; set; }
  public List<Guid>? TypeIds { get; set; }
  public List<string>? Associations { get; set; }
}