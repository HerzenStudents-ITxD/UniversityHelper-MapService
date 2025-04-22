using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityHelper.MapService.Models.Dto.Requests;

public record CreatePointTypeAssociationRequest
{
  [Required]
  public Guid PointTypeId { get; set; }
  [Required]
  public string Association { get; set; }
}