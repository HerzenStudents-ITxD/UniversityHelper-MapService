using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Association.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;

namespace UniversityHelper.MapService.Business.Commands.Association;

public class DeletePointAssociationCommand : IDeletePointAssociationCommand
{
  private readonly IPointAssociationRepository _repository;
  private readonly IAccessValidator _accessValidator;

  public DeletePointAssociationCommand(
      IPointAssociationRepository repository,
      IAccessValidator accessValidator)
  {
    _repository = repository;
    _accessValidator = accessValidator;
  }

  public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid associationId)
  {
    if (!await _accessValidator.IsAdminAsync() && !await _accessValidator.IsModeratorAsync())
    {
      return new OperationResultResponse<bool>
      {
        StatusCode = HttpStatusCode.Forbidden,
        Message = "Only admins or moderators can delete associations."
      };
    }

    if (!await _repository.DoesExistAsync(associationId))
    {
      return new OperationResultResponse<bool>
      {
        StatusCode = HttpStatusCode.NotFound,
        Message = "Association not found."
      };
    }

    var result = await _repository.EditStatusAsync(associationId, false);
    return new OperationResultResponse<bool>
    {
      Body = result
    };
  }
}