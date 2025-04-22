using System;

namespace UniversityHelper.MapService.Models.Dto.Requests;

public record EditRelationRequest
{
  public Guid? FirstPointId { get; set; }
  public Guid? SecondPointId { get; set; }
}