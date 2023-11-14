using Microsoft.AspNetCore.Mvc;
using System;

namespace UniversityHelper.MapService.Models.Dto.Requests.Filters;

public record GetLocationFilter
{
  [FromQuery(Name = "locationId")]
  public Guid LocationId { get; set; }

  [FromQuery(Name = "locale")]
  public string Locale { get; set; }
}
