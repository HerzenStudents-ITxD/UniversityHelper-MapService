using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Point.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;

namespace UniversityHelper.MapService.Business.Commands.Point;

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
    if (!await _accessValidator.IsAdminAsync())
    {
      return new OperationResultResponse<bool>
      (
            body: false,
        errors: new List<string> { "Only admins can delete points." }
      );
    }

    if (!await _repository.DoesExistAsync(pointId))
    {
      return new OperationResultResponse<bool>
      (
            body: false,
        errors: new List<string> { "Point not found." }
      );
    }

    var result = await _repository.EditStatusAsync(pointId, false);
    return new OperationResultResponse<bool>
    {
      Body = result
    };
  }
}