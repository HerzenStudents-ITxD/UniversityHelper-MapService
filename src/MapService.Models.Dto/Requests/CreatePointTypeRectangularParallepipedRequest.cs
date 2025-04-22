using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityHelper.MapService.Models.Dto.Requests;

public record CreatePointTypeRectangularParallepipedRequest
{
  [Required]
  public Guid PointTypeId { get; set; }
  [Required]
  public double XMin { get; set; }
  [Required]
  public double XMax { get; set; }
  [Required]
  public double YMin { get; set; }
  [Required]
  public double YMax { get; set; }
  [Required]
  public double ZMin { get; set; }
  [Required]
  public double ZMax { get; set; }
}