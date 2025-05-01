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
    if (!await _accessValidator.IsAdminAsync())
    {
      return new OperationResultResponse<bool>
      (
         body: false,
         errors: new List<string> { "Only admins can delete point types." }
      );
    }

    if (!await _repository.DoesExistAsync(typeId))
    {
      return new OperationResultResponse<bool>
      (
            body: false,
        errors: new List<string> { "Point type not found." }
      );
    }

    var result = await _repository.EditStatusAsync(typeId, false);
    return new OperationResultResponse<bool>
    {
      Body = result
    };
  }
}