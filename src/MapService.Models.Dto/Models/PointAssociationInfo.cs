using System;

namespace UniversityHelper.MapService.Models.Dto.Models;

public record PointAssociationInfo
{
  public Guid Id { get; set; }
  public string Association { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public bool IsActive { get; set; }
}