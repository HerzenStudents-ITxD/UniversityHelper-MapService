using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Extensions;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.PointType.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Validators.Interfaces;

namespace UniversityHelper.MapService.Business.Commands.PointType;

public class CreatePointTypeCommand : ICreatePointTypeCommand
{
  private readonly IPointTypeRepository _repository;
  private readonly IAccessValidator _accessValidator;
  private readonly IHttpContextAccessor _httpContextAccessor;
  private readonly ICreatePointTypeRequestValidator _validator;

  public CreatePointTypeCommand(
      IPointTypeRepository repository,
      IAccessValidator accessValidator,
      IHttpContextAccessor httpContextAccessor,
      ICreatePointTypeRequestValidator validator)
  {
    _repository = repository;
    _accessValidator = accessValidator;
    _httpContextAccessor = httpContextAccessor;
    _validator = validator;
  }

  public async Task<OperationResultResponse<Guid?>> ExecuteAsync(CreatePointTypeRequest request)
  {
    var validationResult = await _validator.ValidateAsync(request);
    if (!validationResult.IsValid)
    {
      return new OperationResultResponse<Guid?>
      (
            body: null,
        errors: validationResult.Errors.Select(e => e.ErrorMessage).ToList()
      );
    }

    if (!await _accessValidator.IsAdminAsync())
    {
      return new OperationResultResponse<Guid?>
      (
            body: null,
        errors: new List<string> { "Only admins can create point types." }
      );
    }

    if (await _repository.DoesExistByIconAsync(request.Icon))
    {
      return new OperationResultResponse<Guid?>
      (
            body: null,
        errors: new List<string> { "Icon already exists." }
      );
    }

    var pointType = new DbPointType
    {
      Id = Guid.NewGuid(),
      Name = JsonSerializer.Serialize(request.Name),
      Icon = request.Icon,
      Associations = request.Associations?.Select(a => new DbPointTypeAssociation
      {
        Id = Guid.NewGuid(),
        Association = a
      }).ToList() ?? new List<DbPointTypeAssociation>(),
      CreatedBy = _httpContextAccessor.HttpContext.GetUserId(),
      CreatedAtUtc = DateTime.UtcNow,
      IsActive = true
    };

    await _repository.CreateAsync(pointType);
    return new OperationResultResponse<Guid?>
    {
      Body = pointType.Id
    };
  }
}