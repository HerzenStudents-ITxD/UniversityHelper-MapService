using System;

namespace UniversityHelper.MapService.Models.Dto.Requests.Filters;

public record GetPointTypeAssociationsFilter
{
  public Guid PointTypeId { get; set; }
  public bool IncludeDeactivated { get; set; } = false;
}