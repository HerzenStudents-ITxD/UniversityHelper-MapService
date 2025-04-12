using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityHelper.MapService.Models.Dto.Requests;

public record CreatePointRequest
{
  public int CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public bool IsActive { get; set; }
  public bool IsSuggested { get; set; }
  public bool InDevelop { get; set; }
  [Required]
  public List<int> Rights { get; set; }
}
