using System;
using System.Collections.Generic;

namespace UniversityHelper.MapService.Models.Dto.Models;

public record PointLabelInfo
{
  public Guid Id { get; set; }
  public Guid RoleId { get; set; }
  public Dictionary<string, string> Name { get; set; }
  public string Locale { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public bool IsActive { get; set; }
}