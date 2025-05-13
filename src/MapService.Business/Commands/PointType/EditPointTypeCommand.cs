using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.PointType.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Validators.Interfaces;

namespace UniversityHelper.MapService.Business.Commands.PointType;

public class EditPointTypeCommand : IEditPointTypeCommand
{
  private readonly IPointTypeRepository _repository;
  private readonly IAccessValidator _accessValidator;
  private readonly IEditPointTypeRequestValidator _validator;

  public EditPointTypeCommand(
      IPointTypeRepository repository,
      IAccessValidator accessValidator,
      IEditPointTypeRequestValidator validator)
  {
    _repository = repository;
    _accessValidator = accessValidator;
    _validator = validator;
  }

  public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid typeId, EditPointTypeRequest request)
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
        errors: new List<string> { "Only admins can edit point types." }
      );
    }

    var pointType = await _repository.GetAsync(typeId);
    if (pointType == null)
    {
      return new OperationResultResponse<bool>
      (
            body: false,
        errors: new List<string> { "Point type not found." }
      );
    }

    if (request.Name != null)
    {
      pointType.Name = JsonSerializer.Serialize(request.Name);
    }

    // if (request.Icon != null)
    // {
    //   if (await _repository.DoesExistByIconAsync(request.Icon) && pointType.Icon != request.Icon)
    //   {
    //     return new OperationResultResponse<bool>
    //     (
    //         body: false,
    //       errors: new List<string> { "Icon already exists." }
    //     );
    //   }
    //   pointType.Icon = request.Icon;
    // }

    if (request.Associations != null)
    {
      pointType.Associations = request.Associations.Select(a => new DbPointTypeAssociation
      {
        Id = Guid.NewGuid(),
        Association = a
      }).ToList();
    }

    if (request.IsActive.HasValue)
    {
      pointType.IsActive = request.IsActive.Value;
    }

    await _repository.UpdateAsync(pointType);
    return new OperationResultResponse<bool>
    {
      Body = true
    };
  }
}