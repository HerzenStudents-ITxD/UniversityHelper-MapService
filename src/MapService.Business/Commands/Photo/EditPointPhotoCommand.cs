using System;
using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Photo.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Models.Dto.Requests;

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
        Message = "Only admins or moderators can edit photos."
      };
    }

    var photo = await _photoRepository.GetAsync(photoId);
    if (photo == null)
    {
      return new OperationResultResponse<bool>
      {
        StatusCode = HttpStatusCode.NotFound,
        Message = "Photo not found."
      };
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