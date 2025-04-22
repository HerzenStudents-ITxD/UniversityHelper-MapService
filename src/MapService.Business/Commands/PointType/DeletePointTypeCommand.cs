using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.PointType.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;

namespace UniversityHelper.MapService.Business.Commands.PointType;

public class DeletePointTypeCommand : IDeletePointTypeCommand
{
  private readonly IPointTypeRepository _repository;
  private readonly IAccessValidator _accessValidator;

  public DeletePointTypeCommand(
      IPointTypeRepository repository,
      IAccessValidator accessValidator)
  {
    _repository = repository;
    _accessValidator = accessValidator;
  }

  public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid typeId)
  {
    if (!await _accessValidator.IsAdminAsync() && !await _accessValidator.IsModeratorAsync())
    {
      return new OperationResultResponse<bool>
      {
        StatusCode = HttpStatusCode.Forbidden,
        Message = "Only admins or moderators can delete point types."
      };
    }

    if (!await _repository.DoesExistAsync(typeId))
    {
      return new OperationResultResponse<bool>
      {
        StatusCode = HttpStatusCode.NotFound,
        Message = "Point type not found."
      };
    }

    var result = await _repository.EditStatusAsync(typeId, false);
    return new OperationResultResponse<bool>
    {
      Body = result
    };
  }
}