using System;
using System.Collections.Generic;

namespace UniversityHelper.MapService.Models.Dto.Requests;

public record EditPointRequest
{
  public Dictionary<string, string>? Name { get; set; }
  public Dictionary<string, string>? Description { get; set; }
  public Dictionary<string, string>? Fact { get; set; }
  public float? X { get; set; }
  public float? Y { get; set; }
  public float? Z { get; set; }
  public string? Icon { get; set; }
  public List<Guid>? LabelIds { get; set; }
  public List<CreatePointPhotoRequest>? Photos { get; set; }
  public List<Guid>? TypeIds { get; set; }
  public List<string>? Associations { get; set; }
  public bool? IsActive { get; set; }
}