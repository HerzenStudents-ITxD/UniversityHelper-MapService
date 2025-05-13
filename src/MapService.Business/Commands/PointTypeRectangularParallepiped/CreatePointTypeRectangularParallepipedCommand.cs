using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Extensions;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.PointTypeRectangularParallepiped.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Validators.Interfaces;

namespace UniversityHelper.MapService.Business.Commands.PointTypeRectangularParallepiped;

public class CreatePointTypeRectangularParallepipedCommand : ICreatePointTypeRectangularParallepipedCommand
{
  private readonly IPointTypeRectangularParallepipedRepository _parallelepipedRepository;
  private readonly IPointTypeRepository _pointTypeRepository;
  private readonly IAccessValidator _accessValidator;
  private readonly IHttpContextAccessor _httpContextAccessor;
  private readonly ICreatePointTypeRectangularParallepipedRequestValidator _validator;

  public CreatePointTypeRectangularParallepipedCommand(
      IPointTypeRectangularParallepipedRepository parallelepipedRepository,
      IPointTypeRepository pointTypeRepository,
      IAccessValidator accessValidator,
      IHttpContextAccessor httpContextAccessor,
      ICreatePointTypeRectangularParallepipedRequestValidator validator)
  {
    _parallelepipedRepository = parallelepipedRepository;
    _pointTypeRepository = pointTypeRepository;
    _accessValidator = accessValidator;
    _httpContextAccessor = httpContextAccessor;
    _validator = validator;
  }

  public async Task<OperationResultResponse<Guid?>> ExecuteAsync(CreatePointTypeRectangularParallepipedRequest request)
  {
    // var validationResult = await _validator.ValidateAsync(request);
    // if (!validationResult.IsValid)
    // {
    //   return new OperationResultResponse<Guid?>
    //   (
    //         body: null,
    //     errors: validationResult.Errors.Select(e => e.ErrorMessage).ToList()
    //   );
    // }

    if (!await _accessValidator.IsAdminAsync())
    {
      return new OperationResultResponse<Guid?>
      (
            body: null,
        errors: new List<string> { "Only admins create parallelepipeds." }
      );
    }

    if (!await _pointTypeRepository.DoesExistAsync(request.PointTypeId))
    {
      return new OperationResultResponse<Guid?>
      (
            body: null,
        errors: new List<string> { "Point type not found." }
      );
    }

    var parallelepiped = new DbPointTypeRectangularParallelepiped
    {
      Id = Guid.NewGuid(),
      PointTypeId = request.PointTypeId,
      XMin = (float)request.XMin,
      XMax = (float)request.XMax,
      YMin = (float)request.YMin,
      YMax = (float)request.YMax,
      ZMin = (float)request.ZMin,
      ZMax = (float)request.ZMax,
      CreatedBy = _httpContextAccessor.HttpContext.GetUserId(),
      CreatedAtUtc = DateTime.UtcNow,
      IsActive = true
    };

    await _parallelepipedRepository.CreateAsync(parallelepiped);
    return new OperationResultResponse<Guid?>
    {
      Body = parallelepiped.Id
    };
  }
}