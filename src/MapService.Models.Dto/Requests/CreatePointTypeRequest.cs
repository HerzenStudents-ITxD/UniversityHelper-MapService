using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityHelper.MapService.Models.Dto.Requests;

public record CreatePointTypeRequest
{
  [Required]
  public Dictionary<string, string> Name { get; set; }
  [Required]
  public string Icon { get; set; }
  public List<string>? Associations { get; set; }
}