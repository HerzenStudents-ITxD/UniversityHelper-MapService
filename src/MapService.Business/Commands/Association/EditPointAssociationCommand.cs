using System;
using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Association.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Validators.Interfaces;
namespace UniversityHelper.MapService.Business.Commands.Association;

public class EditPointAssociationCommand : IEditPointAssociationCommand
{
  private readonly IPointAssociationRepository _repository;
  private readonly IAccessValidator _accessValidator;
  private readonly IEditPointAssociationRequestValidator _validator;

  public EditPointAssociationCommand(
      IPointAssociationRepository repository,
      IAccessValidator accessValidator,
      IEditPointAssociationRequestValidator validator)
  {
    _repository = repository;
    _accessValidator = accessValidator;
    _validator = validator;
  }

  public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid associationId, EditPointAssociationRequest request)
  {
    var validationResult = await _validator.ValidateAsync(request);
    if (!validationResult.IsValid)
    {
      return new OperationResultResponse<bool>
      (
            body: false,
        errors: validationResult.Errors.Select(e => e.ErrorMessage).ToList()
      );
    }

    if (!await _accessValidator.IsAdminAsync())
    {
      return new OperationResultResponse<bool>
      (
            body: false,
        errors: new List<string> { "Only admins can edit associations." }
      );
    }

    var association = await _repository.GetAsync(associationId);
    if (association == null)
    {
      return new OperationResultResponse<bool>
      (
            body: false,
        errors: new List<string> { "Association not found." }
      );
    }

    if (request.Association != null)
    {
      if (await _repository.DoesExistByNameAsync(request.Association) && association.Association != request.Association)
      {
        return new OperationResultResponse<bool>
        (
            body: false,
          errors: new List<string> { "Association already exists." }
        );
      }

      association.Association = request.Association;
    }

    if (request.IsActive.HasValue)
    {
      association.IsActive = request.IsActive.Value;
    }

    await _repository.UpdateAsync(association);
    return new OperationResultResponse<bool>
    {
      Body = true
    };
  }
}