using System;
using System.Collections.Generic;

namespace UniversityHelper.MapService.Models.Dto.Models;

public record PointTypeInfo
{
  public Guid Id { get; set; }
  public Dictionary<string, string> Name { get; set; }
  public string Icon { get; set; }
  public List<string> Associations { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public bool IsActive { get; set; }
}