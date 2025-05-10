using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Relation.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;

namespace UniversityHelper.MapService.Business.Commands.Relation;

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
    if (!await _accessValidator.IsAdminAsync())
    {
      return new OperationResultResponse<bool>
      (
            body: false,
        errors: new List<string> { "Only admins can delete relations." }
      );
    }

    if (!await _relationRepository.DoesExistAsync(relationId))
    {
      return new OperationResultResponse<bool>
      (
            body: false,
        errors: new List<string> { "Relation not found." }
      );
    }

    var result = await _relationRepository.DeleteAsync(relationId);
    return new OperationResultResponse<bool>
    {
      Body = result
    };
  }
}