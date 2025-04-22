namespace UniversityHelper.MapService.Models.Dto.Requests;

public record EditPointTypeAssociationRequest
{
  public string? Association { get; set; }
  public bool? IsActive { get; set; }
}