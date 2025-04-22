using System;

namespace UniversityHelper.MapService.Models.Dto.Requests.Filters;

public record GetPointPhotosFilter
{
  public Guid PointId { get; set; }
  public bool IncludeDeactivated { get; set; } = false;
}