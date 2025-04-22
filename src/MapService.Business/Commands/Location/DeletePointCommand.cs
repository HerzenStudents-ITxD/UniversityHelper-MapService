using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Location.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;

namespace UniversityHelper.MapService.Business.Commands.Location;

public class DeletePointCommand : IDeletePointCommand
{
  private readonly IPointRepository _repository;
  private readonly IAccessValidator _accessValidator;

  public DeletePointCommand(
      IPointRepository repository,
      IAccessValidator accessValidator)
  {
    _repository = repository;
    _accessValidator = accessValidator;
  }

  public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid pointId)
  {
    if (!await _accessValidator.IsAdminAsync() && !await _accessValidator.IsModeratorAsync())
    {
      return new OperationResultResponse<bool>
      {
        StatusCode = HttpStatusCode.Forbidden,
        Message = "Only admins or moderators can delete points."
      };
    }

    if (!await _repository.DoesExistAsync(pointId))
    {
      return new OperationResultResponse<bool>
      {
        StatusCode = HttpStatusCode.NotFound,
        Message = "Point not found."
      };
    }

    var result = await _repository.EditStatusAsync(pointId, false);
    return new OperationResultResponse<bool>
    {
      Body = result
    };
  }
}