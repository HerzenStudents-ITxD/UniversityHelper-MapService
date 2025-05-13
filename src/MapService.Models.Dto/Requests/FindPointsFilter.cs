namespace UniversityHelper.MapService.Models.Dto.Requests.Filters;

public record FindPointsFilter
{
  public bool IncludeDeactivated { get; set; } = false;
  public Guid? CreatedBy { get; set; }
  public string? Locale { get; set; }
  public string? TypeId { get; set; }
  public int? Page { get; set; }
  public int? PageSize { get; set; }
}