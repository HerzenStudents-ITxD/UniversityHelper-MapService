using System;

namespace UniversityHelper.MapService.Models.Dto.Models;

public record PointTypeRectangularParallepipedInfo
{
  public Guid Id { get; set; }
  public Guid PointTypeId { get; set; }
  public double XMin { get; set; }
  public double XMax { get; set; }
  public double YMin { get; set; }
  public double YMax { get; set; }
  public double ZMin { get; set; }
  public double ZMax { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public bool IsActive { get; set; }
}