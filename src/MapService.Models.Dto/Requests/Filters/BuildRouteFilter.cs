using System;

namespace UniversityHelper.MapService.Models.Dto.Requests.Filters;

public record BuildRouteFilter
{
  public Guid StartPointId { get; set; }
  public Guid EndPointId { get; set; }
  public string Locale { get; set; }
}