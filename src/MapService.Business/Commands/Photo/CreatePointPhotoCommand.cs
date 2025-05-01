using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Extensions;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Photo.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Validators.Interfaces;

namespace UniversityHelper.MapService.Business.Commands.Photo;

public class CreatePointPhotoCommand : ICreatePointPhotoCommand
{
  private readonly IPointPhotoRepository _photoRepository;
  private readonly IPointRepository _pointRepository;
  private readonly IAccessValidator _accessValidator;
  private readonly IHttpContextAccessor _httpContextAccessor;
  private readonly ICreatePointPhotoRequestValidator _validator;

  public CreatePointPhotoCommand(
      IPointPhotoRepository photoRepository,
      IPointRepository pointRepository,
      IAccessValidator accessValidator,
      IHttpContextAccessor httpContextAccessor,
      ICreatePointPhotoRequestValidator validator)
  {
    _photoRepository = photoRepository;
    _pointRepository = pointRepository;
    _accessValidator = accessValidator;
    _httpContextAccessor = httpContextAccessor;
    _validator = validator;
  }

  public async Task<OperationResultResponse<Guid?>> ExecuteAsync(CreatePointPhotoRequest request)
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
        errors: new List<string> { "Only admins can create photos." }
      );
    }

    if (!await _pointRepository.DoesExistAsync(request.PointId))
    {
      return new OperationResultResponse<Guid?>
      (
            body: null,
        errors: new List<string> { "Point not found." }
      );
    }

    var photo = new DbPointPhoto
    {
      Id = Guid.NewGuid(),
      PointId = request.PointId,
      Content = request.Content,
      OrdinalNumber = request.OrdinalNumber,
      CreatedBy = _httpContextAccessor.HttpContext.GetUserId(),
      CreatedAtUtc = DateTime.UtcNow,
      IsActive = true
    };

    await _photoRepository.CreateAsync(photo);
    return new OperationResultResponse<Guid?>
    {
      Body = photo.Id
    };
  }
}