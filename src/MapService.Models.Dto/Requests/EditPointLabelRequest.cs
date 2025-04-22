using System.Collections.Generic;

namespace UniversityHelper.MapService.Models.Dto.Requests;

public record EditPointLabelRequest
{
  public Dictionary<string, string>? Name { get; set; }
  public bool? IsActive { get; set; }
}