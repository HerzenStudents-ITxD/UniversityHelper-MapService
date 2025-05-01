using System;
using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Photo.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Validators.Interfaces;

namespace UniversityHelper.MapService.Business.Commands.Photo;

public class EditPointPhotoCommand : IEditPointPhotoCommand
{
  private readonly IPointPhotoRepository _photoRepository;
  private readonly IAccessValidator _accessValidator;
  private readonly IEditPointPhotoRequestValidator _validator;

  public EditPointPhotoCommand(
      IPointPhotoRepository photoRepository,
      IAccessValidator accessValidator,
      IEditPointPhotoRequestValidator validator)
  {
    _photoRepository = photoRepository;
    _accessValidator = accessValidator;
    _validator = validator;
  }

  public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid photoId, EditPointPhotoRequest request)
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
        errors: new List<string> { "Only admins can edit photos." }
      );
    }

    var photo = await _photoRepository.GetAsync(photoId);
    if (photo == null)
    {
      return new OperationResultResponse<bool>
      (
            body: false,
        errors: new List<string> { "Photo not found." }
      );
    }

    if (request.Content != null)
    {
      photo.Content = request.Content;
    }

    if (request.OrdinalNumber.HasValue)
    {
      photo.OrdinalNumber = request.OrdinalNumber.Value;
    }

    if (request.IsActive.HasValue)
    {
      photo.IsActive = request.IsActive.Value;
    }

    await _photoRepository.UpdateAsync(photo);
    return new OperationResultResponse<bool>
    {
      Body = true
    };
  }
}