namespace UniversityHelper.MapService.Models.Dto.Requests.Filters;

public record GetPointAssociationsFilter
{
  public bool IncludeDeactivated { get; set; } = false;
}