using System;
using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.PointTypeAssociation.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Business.Commands.PointTypeAssociation;

public class EditPointTypeAssociationCommand : IEditPointTypeAssociationCommand
{
  private readonly IPointTypeAssociationRepository _associationRepository;
  private readonly IAccessValidator _accessValidator;
  private readonly IEditPointTypeAssociationRequestValidator _validator;

  public EditPointTypeAssociationCommand(
      IPointTypeAssociationRepository associationRepository,
      IAccessValidator accessValidator,
      IEditPointTypeAssociationRequestValidator validator)
  {
    _associationRepository = associationRepository;
    _accessValidator = accessValidator;
    _validator = validator;
  }

  public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid associationId, EditPointTypeAssociationRequest request)
  {
    var validationResult = await _validator.ValidateAsync(request);
    if (!validationResult.IsValid)
    {
      return new OperationResultResponse<bool>
      {
        StatusCode = HttpStatusCode.BadRequest,
        Message = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage))
      };
    }

    if (!await _accessValidator.IsAdminAsync() && !await _accessValidator.IsModeratorAsync())
    {
      return new OperationResultResponse<bool>
      {
        StatusCode = HttpStatusCode.Forbidden,
        Message = "Only admins or moderators can edit associations."
      };
    }

    var association = await _associationRepository.GetAsync(associationId);
    if (association == null)
    {
      return new OperationResultResponse<bool>
      {
        StatusCode = HttpStatusCode.NotFound,
        Message = "Association not found."
      };
    }

    if (request.Association != null)
    {
      if (await _associationRepository.DoesExistByNameAndTypeAsync(association.PointTypeId, request.Association) &&
          association.Association != request.Association)
      {
        return new OperationResultResponse<bool>
        {
          StatusCode = HttpStatusCode.Conflict,
          Message = "Association already exists for this point type."
        };
      }
      association.Association = request.Association;
    }

    if (request.IsActive.HasValue)
    {
      association.IsActive = request.IsActive.Value;
    }

    await _associationRepository.UpdateAsync(association);
    return new OperationResultResponse<bool>
    {
      Body = true
    };
  }
}