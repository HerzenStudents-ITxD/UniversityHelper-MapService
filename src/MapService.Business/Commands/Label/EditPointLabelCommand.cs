using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Label.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Business.Commands.Label;

public class EditPointLabelCommand : IEditPointLabelCommand
{
  private readonly IPointLabelRepository _repository;
  private readonly IAccessValidator _accessValidator;

  public EditPointLabelCommand(
      IPointLabelRepository repository,
      IAccessValidator accessValidator)
  {
    _repository = repository;
    _accessValidator = accessValidator;
  }

  public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid labelId, EditPointLabelRequest request)
  {
    if (!await _accessValidator.IsAdminAsync() && !await _accessValidator.IsModeratorAsync())
    {
      return new OperationResultResponse<bool>
      {
        StatusCode = HttpStatusCode.Forbidden,
        Message = "Only admins or moderators can edit labels."
      };
    }

    var label = await _repository.GetAsync(labelId);
    if (label == null)
    {
      return new OperationResultResponse<bool>
      {
        StatusCode = HttpStatusCode.NotFound,
        Message = "Label not found."
      };
    }

    if (request.Name != null)
    {
      label.Name = JsonSerializer.Serialize(request.Name);
    }

    if (request.IsActive.HasValue)
    {
      label.IsActive = request.IsActive.Value;
    }

    await _repository.UpdateAsync(label);
    return new OperationResultResponse<bool>
    {
      Body = true
    };
  }
}