using System;
using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Route.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Business.Commands.Route;

public class EditRelationCommand : IEditRelationCommand
{
  private readonly IRelationRepository _relationRepository;
  private readonly IPointRepository _pointRepository;
  private readonly IAccessValidator _accessValidator;

  public EditRelationCommand(
      IRelationRepository relationRepository,
      IPointRepository pointRepository,
      IAccessValidator accessValidator)
  {
    _relationRepository = relationRepository;
    _pointRepository = pointRepository;
    _accessValidator = accessValidator;
  }

  public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid relationId, EditRelationRequest request)
  {
    if (!await _accessValidator.IsAdminAsync())
    {
      return new OperationResultResponse<bool>
      (
            body: false,
        errors: new List<string> { "Only admins can edit relations." }
      );
    }

    var relation = await _relationRepository.GetAsync(relationId);
    if (relation == null)
    {
      return new OperationResultResponse<bool>
      (
            body: false,
        errors: new List<string> { "Relation not found." }
      );
    }

    if (request.FirstPointId.HasValue)
    {
      if (!await _pointRepository.DoesExistAsync(request.FirstPointId.Value))
      {
        return new OperationResultResponse<bool>
        (
            body: false, 
            errors: new List<string> { "First point not found." }
        );
      }
      relation.FirstPointId = request.FirstPointId.Value;
    }

    if (request.SecondPointId.HasValue)
    {
      if (!await _pointRepository.DoesExistAsync(request.SecondPointId.Value))
      {
        return new OperationResultResponse<bool>
        (
            body: false,
          errors: new List<string> { "Second point not found." }
        );
      }
      relation.SecondPointId = request.SecondPointId.Value;
    }

    await _relationRepository.UpdateAsync(relation);
    return new OperationResultResponse<bool>
    {
      Body = true
    };
  }
}