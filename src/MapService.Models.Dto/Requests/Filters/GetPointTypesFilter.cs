namespace UniversityHelper.MapService.Models.Dto.Requests.Filters;

public record GetPointTypesFilter
{
  public string? Locale { get; set; }
  public bool IncludeDeactivated { get; set; } = false;
}