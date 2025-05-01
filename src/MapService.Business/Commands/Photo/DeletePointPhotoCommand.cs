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
    if (!await _accessValidator.IsAdminAsync())
    {
      return new OperationResultResponse<bool>
      (
            body: false,
        errors: new List<string> { "Only admins can delete photos." }
      );
    }

    if (!await _photoRepository.DoesExistAsync(photoId))
    {
      return new OperationResultResponse<bool>
      (
            body: false,
        errors: new List<string> { "Photo not found." }
      );
    }

    var result = await _photoRepository.EditStatusAsync(photoId, false);
    return new OperationResultResponse<bool>
    {
      Body = result
    };
  }
}