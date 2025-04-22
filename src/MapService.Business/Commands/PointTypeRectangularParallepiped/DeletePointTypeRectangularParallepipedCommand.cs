using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.PointTypeRectangularParallepiped.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;

namespace UniversityHelper.MapService.Business.Commands.PointTypeRectangularParallepiped;

public class DeletePointTypeRectangularParallepipedCommand : IDeletePointTypeRectangularParallepipedCommand
{
  private readonly IPointTypeRectangularParallepipedRepository _parallelepipedRepository;
  private readonly IAccessValidator _accessValidator;

  public DeletePointTypeRectangularParallepipedCommand(
      IPointTypeRectangularParallepipedRepository parallelepipedRepository,
      IAccessValidator accessValidator)
  {
    _parallelepipedRepository = parallelepipedRepository;
    _accessValidator = accessValidator;
  }

  public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid parallelepipedId)
  {
    if (!await _accessValidator.IsAdminAsync() && !await _accessValidator.IsModeratorAsync())
    {
      return new OperationResultResponse<bool>
      {
        StatusCode = HttpStatusCode.Forbidden,
        Message = "Only admins or moderators can delete parallelepipeds."
      };
    }

    if (!await _parallelepipedRepository.DoesExistAsync(parallelepipedId))
    {
      return new OperationResultResponse<bool>
      {
        StatusCode = HttpStatusCode.NotFound,
        Message = "Parallelepiped not found."
      };
    }

    var result = await _parallelepipedRepository.EditStatusAsync(parallelepipedId, false);
    return new OperationResultResponse<bool>
    {
      Body = result
    };
  }
}