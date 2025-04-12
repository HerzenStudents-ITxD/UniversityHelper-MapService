using System.Collections.Generic;
using UniversityHelper.MapService.Models.Dto.Models;

namespace UniversityHelper.MapService.Models.Dto.Responses;

public record PointResponse
{
  public PointInfo Role { get; set; }
}
