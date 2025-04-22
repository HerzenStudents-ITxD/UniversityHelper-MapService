using System;

namespace UniversityHelper.MapService.Models.Dto.Requests;

public record EditPointPhotoRequest
{
  public string? Content { get; set; }
  public int? OrdinalNumber { get; set; }
  public bool? IsActive { get; set; }
}