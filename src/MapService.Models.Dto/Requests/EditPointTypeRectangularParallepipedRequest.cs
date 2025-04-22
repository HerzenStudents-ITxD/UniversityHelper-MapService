namespace UniversityHelper.MapService.Models.Dto.Requests;

public record EditPointTypeRectangularParallepipedRequest
{
  public double? XMin { get; set; }
  public double? XMax { get; set; }
  public double? YMin { get; set; }
  public double? YMax { get; set; }
  public double? ZMin { get; set; }
  public double? ZMax { get; set; }
  public bool? IsActive { get; set; }
}