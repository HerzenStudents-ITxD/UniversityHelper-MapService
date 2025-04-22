using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityHelper.MapService.Models.Dto.Requests;

public record CreatePointPhotoRequest
{
  [Required]
  public Guid PointId { get; set; }
  [Required]
  public string Content { get; set; }
  public int OrdinalNumber { get; set; }
}