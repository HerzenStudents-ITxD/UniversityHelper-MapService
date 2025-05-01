using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic; // Добавлено для List<string>
using System.Linq;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Extensions;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Association.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Validators.Interfaces;

namespace UniversityHelper.MapService.Business.Commands.Association;

public class CreatePointAssociationCommand : ICreatePointAssociationCommand
{
  private readonly IPointAssociationRepository _repository;
  private readonly IAccessValidator _accessValidator;
  private readonly IHttpContextAccessor _httpContextAccessor;
  private readonly ICreatePointAssociationRequestValidator _validator;

  public CreatePointAssociationCommand(
      IPointAssociationRepository repository,
      IAccessValidator accessValidator,
      IHttpContextAccessor httpContextAccessor,
      ICreatePointAssociationRequestValidator validator)
  {
    _repository = repository;
    _accessValidator = accessValidator;
    _httpContextAccessor = httpContextAccessor;
    _validator = validator;
  }

  public async Task<OperationResultResponse<Guid?>> ExecuteAsync(CreatePointAssociationRequest request)
  {
    var validationResult = await _validator.ValidateAsync(request);
    if (!validationResult.IsValid)
    {
      return new OperationResultResponse<Guid?>(
          body: null,
          errors: validationResult.Errors.Select(e => e.ErrorMessage).ToList()
      );
    }

    if (!await _accessValidator.IsAdminAsync())
    {
      return new OperationResultResponse<Guid?>(
          body: null,
          errors: new List<string> { "Only admins can create associations." }
      );
    }

    if (await _repository.DoesExistByNameAsync(request.Association))
    {
      return new OperationResultResponse<Guid?>(
          body: null,
          errors: new List<string> { "Association already exists." }
      );
    }

    var association = new DbPointTypeAssociation
    {
      Id = Guid.NewGuid(),
      Association = request.Association,
      CreatedBy = _httpContextAccessor.HttpContext.GetUserId(),
      CreatedAtUtc = DateTime.UtcNow,
      IsActive = true
    };

    await _repository.CreateAsync(association);
    return new OperationResultResponse<Guid?>(
        body: association.Id,
        errors: new List<string>()
    );
  }
}