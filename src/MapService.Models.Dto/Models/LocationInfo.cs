using System;
using System.Collections.Generic;

namespace UniversityHelper.MapService.Models.Dto.Models;

public record PointInfo
{
  public Guid Id { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public bool IsActive { get; set; }
  public IEnumerable<PointLabelInfo> Labels { get; set; }
}
