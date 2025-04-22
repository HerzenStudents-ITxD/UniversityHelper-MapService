using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Route.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;

namespace UniversityHelper.MapService.Business.Commands.Route;

public class DeleteRelationCommand : IDeleteRelationCommand
{
  private readonly IRelationRepository _relationRepository;
  private readonly IAccessValidator _accessValidator;

  public DeleteRelationCommand(
      IRelationRepository relationRepository,
      IAccessValidator accessValidator)
  {
    _relationRepository = relationRepository;
    _accessValidator = accessValidator;
  }

  public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid relationId)
  {
    if (!await _accessValidator.IsAdminAsync() && !await _accessValidator.IsModeratorAsync())
    {
      return new OperationResultResponse<bool>
      {
        StatusCode = HttpStatusCode.Forbidden,
        Message = "Only admins or moderators can delete relations."
      };
    }

    if (!await _relationRepository.DoesExistAsync(relationId))
    {
      return new OperationResultResponse<bool>
      {
        StatusCode = HttpStatusCode.NotFound,
        Message = "Relation not found."
      };
    }

    var result = await _relationRepository.DeleteAsync(relationId);
    return new OperationResultResponse<bool>
    {
      Body = result
    };
  }
}