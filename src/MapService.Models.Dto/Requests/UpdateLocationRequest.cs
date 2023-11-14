namespace UniversityHelper.MapService.Models.Dto.Requests;

public class UpdateLocationRequest
{
  public string Name { get; set; }
  public string Description { get; set; }
  public bool IsActive { get; set; }
}
