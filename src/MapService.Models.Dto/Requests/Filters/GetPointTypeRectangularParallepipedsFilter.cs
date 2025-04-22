using System;

namespace UniversityHelper.MapService.Models.Dto.Requests.Filters;

public record GetPointTypeRectangularParallepipedsFilter
{
  public Guid PointTypeId { get; set; }
  public bool IncludeDeactivated { get; set; } = false;
}