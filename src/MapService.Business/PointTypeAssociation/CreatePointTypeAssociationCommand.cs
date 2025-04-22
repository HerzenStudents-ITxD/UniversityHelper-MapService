using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Extensions;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.PointTypeAssociation.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Business.Commands.PointTypeAssociation;

public class CreatePointTypeAssociationCommand : ICreatePointTypeAssociationCommand
{
  private readonly IPointTypeAssociationRepository _associationRepository;
  private readonly IPointTypeRepository _pointTypeRepository;
  private readonly IAccessValidator _accessValidator;
  private readonly IHttpContextAccessor _httpContextAccessor;
  private readonly ICreatePointTypeAssociationRequestValidator _validator;

  public CreatePointTypeAssociationCommand(
      IPointTypeAssociationRepository associationRepository,
      IPointTypeRepository pointTypeRepository,
      IAccessValidator accessValidator,
      IHttpContextAccessor httpContextAccessor,
      ICreatePointTypeAssociationRequestValidator validator)
  {
    _associationRepository = associationRepository;
    _pointTypeRepository = pointTypeRepository;
    _accessValidator = accessValidator;
    _httpContextAccessor = httpContextAccessor;
    _validator = validator;
  }

  public async Task<OperationResultResponse<Guid?>> ExecuteAsync(CreatePointTypeAssociationRequest request)
  {
    var validationResult = await _validator.ValidateAsync(request);
    if (!validationResult.IsValid)
    {
      return new OperationResultResponse<Guid?>
      {
        StatusCode = HttpStatusCode.BadRequest,
        Message = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage))
      };
    }

    if (!await _accessValidator.IsAdminAsync() && !await _accessValidator.IsModeratorAsync())
    {
      return new OperationResultResponse<Guid?>
      {
        StatusCode = HttpStatusCode.Forbidden,
        Message = "Only admins or moderators can create associations."
      };
    }

    if (!await _pointTypeRepository.DoesExistAsync(request.PointTypeId))
    {
      return new OperationResultResponse<Guid?>
      {
        StatusCode = HttpStatusCode.NotFound,
        Message = "Point type not found."
      };
    }

    if (await _associationRepository.DoesExistByNameAndTypeAsync(request.PointTypeId, request.Association))
    {
      return new OperationResultResponse<Guid?>
      {
        StatusCode = HttpStatusCode.Conflict,
        Message = "Association already exists for this point type."
      };
    }

    var association = new DbPointTypeAssociation
    {
      Id = Guid.NewGuid(),
      PointTypeId = request.PointTypeId,
      Association = request.Association,
      CreatedBy = _httpContextAccessor.HttpContext.GetUserId(),
      CreatedAtUtc = DateTime.UtcNow,
      IsActive = true
    };

    await _associationRepository.CreateAsync(association);
    return new OperationResultResponse<Guid?>
    {
      Body = association.Id
    };
  }
}