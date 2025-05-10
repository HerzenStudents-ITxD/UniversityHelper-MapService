using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityHelper.MapService.Models.Dto.Requests;

public record CreatePointLabelRequest
{
  [Required]
  public Dictionary<string, string> Name { get; set; } // JSON: {"ru": "Метка 1", "en": "Label 1", "cn": "标签 1"}
}