using System;

namespace UniversityHelper.MapService.Models.Dto.Requests.Filters;

public record AvailableRoutesFilter
{
  public Guid PointId { get; set; }
  public string Locale { get; set; }
}