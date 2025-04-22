using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityHelper.MapService.Models.Dto.Requests;

public record CreateRelationRequest
{
  [Required]
  public Guid FirstPointId { get; set; }
  [Required]
  public Guid SecondPointId { get; set; }
}