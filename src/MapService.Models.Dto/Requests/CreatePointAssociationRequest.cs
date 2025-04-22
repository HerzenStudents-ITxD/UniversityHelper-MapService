using System.ComponentModel.DataAnnotations;

namespace UniversityHelper.MapService.Models.Dto.Requests;

public record CreatePointAssociationRequest
{
  [Required]
  public string Association { get; set; }
}