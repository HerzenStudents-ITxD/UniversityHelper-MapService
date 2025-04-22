using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Label.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;

namespace UniversityHelper.MapService.Business.Commands.Label;

public class DeletePointLabelCommand : IDeletePointLabelCommand
{
  private readonly IPointLabelRepository _repository;
  private readonly IAccessValidator _accessValidator;

  public DeletePointLabelCommand(
      IPointLabelRepository repository,
      IAccessValidator accessValidator)
  {
    _repository = repository;
    _accessValidator = accessValidator;
  }

  public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid labelId)
  {
    if (!await _accessValidator.IsAdminAsync() && !await _accessValidator.IsModeratorAsync())
    {
      return new OperationResultResponse<bool>
      {
        StatusCode = HttpStatusCode.Forbidden,
        Message = "Only admins or moderators can delete labels."
      };
    }

    if (!await _repository.DoesExistAsync(labelId))
    {
      return new OperationResultResponse<bool>
      {
        StatusCode = HttpStatusCode.NotFound,
        Message = "Label not found."
      };
    }

    var result = await _repository.EditStatusAsync(labelId, false);
    return new OperationResultResponse<bool>
    {
      Body = result
    };
  }
}