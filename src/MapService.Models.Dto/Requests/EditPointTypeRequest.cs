using System.Collections.Generic;

namespace UniversityHelper.MapService.Models.Dto.Requests;

public record EditPointTypeRequest
{
  public Dictionary<string, string>? Name { get; set; }
  public string? Icon { get; set; }
  public List<string>? Associations { get; set; }
  public bool? IsActive { get; set; }
}