namespace UniversityHelper.MapService.Models.Dto.Requests;

public record EditPointAssociationRequest
{
  public string? Association { get; set; }
  public bool? IsActive { get; set; }
}