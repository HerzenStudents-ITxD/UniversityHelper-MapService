using System;

namespace UniversityHelper.MapService.Models.Dto.Requests.Filters;

public record AvailableRelationsFilter
{
  public Guid PointId { get; set; }
  public string Locale { get; set; }
}