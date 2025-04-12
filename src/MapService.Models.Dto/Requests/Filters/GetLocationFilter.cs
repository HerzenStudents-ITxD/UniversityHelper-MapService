using Microsoft.AspNetCore.Mvc;
using System;

namespace UniversityHelper.MapService.Models.Dto.Requests.Filters;

public record GetPointFilter
{
  [FromQuery(Name = "pointId")]
  public Guid PointId { get; set; }

  [FromQuery(Name = "locale")]
  public string Locale { get; set; }
}
