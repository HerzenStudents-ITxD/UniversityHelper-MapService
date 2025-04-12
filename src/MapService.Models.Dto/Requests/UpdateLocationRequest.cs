namespace UniversityHelper.MapService.Models.Dto.Requests;

public class UpdatePointRequest
{
  public string Name { get; set; }
  public string Description { get; set; }
  public bool IsActive { get; set; }
}
