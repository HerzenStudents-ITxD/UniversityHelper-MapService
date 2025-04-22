using System;

namespace UniversityHelper.MapService.Models.Dto.Models;

public record PointPhotoInfo
{
  public Guid Id { get; set; }
  public Guid PhotoId { get; set; }
  public int Number { get; set; }
  public bool IsActive { get; set; }
}