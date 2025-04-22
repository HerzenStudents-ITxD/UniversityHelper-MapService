using System;

namespace UniversityHelper.MapService.Models.Dto.Models;

public record PointTypeAssociationInfo
{
  public Guid Id { get; set; }
  public Guid PointTypeId { get; set; }
  public string Association { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public bool IsActive { get; set; }
}