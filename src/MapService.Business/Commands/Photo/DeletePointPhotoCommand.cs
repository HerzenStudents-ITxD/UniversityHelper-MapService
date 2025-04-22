using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Photo.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;

namespace UniversityHelper.MapService.Business.Commands.Photo;

public class DeletePointPhotoCommand : IDeletePointPhotoCommand
{
  private readonly IPointPhotoRepository _photoRepository;
  private readonly IAccessValidator _accessValidator;

  public DeletePointPhotoCommand(
      IPointPhotoRepository photoRepository,
      IAccessValidator accessValidator)
  {
    _photoRepository = photoRepository;
    _accessValidator = accessValidator;
  }

  public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid photoId)
  {
    if (!await _accessValidator.IsAdminAsync() && !await _accessValidator.IsModeratorAsync())
    {
      return new OperationResultResponse<bool>
      {
        StatusCode = HttpStatusCode.Forbidden,
        Message = "Only admins or moderators can delete photos."
      };
    }

    if (!await _photoRepository.DoesExistAsync(photoId))
    {
      return new OperationResultResponse<bool>
      {
        StatusCode = HttpStatusCode.NotFound,
        Message = "Photo not found."
      };
    }

    var result = await _photoRepository.EditStatusAsync(photoId, false);
    return new OperationResultResponse<bool>
    {
      Body = result
    };
  }
}