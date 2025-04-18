﻿using UniversityHelper.Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace UniversityHelper.MapService.Models.Dto.Requests.Filters;

public record FindPointsFilter : BaseFindFilter
{
  [FromQuery(Name = "locale")]
  public string Locale { get; set; }

  [FromQuery(Name = "createdBy")]
  public int CreatedBy { get; set; }

  [FromQuery(Name = "includeDeactivated")]
  public bool IncludeDeactivated { get; set; }

  [FromQuery(Name = "includeSuggested")]
  public bool IncludeSuggested { get; set; }

  [FromQuery(Name = "includeDeveloped")]
  public bool IncludeDeveloped { get; set; }
}
