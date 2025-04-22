using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Extensions;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Label.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Business.Commands.Label;

public class CreatePointLabelCommand : ICreatePointLabelCommand
{
  private readonly IPointLabelRepository _repository;
  private readonly IAccessValidator _accessValidator;
  private readonly IHttpContextAccessor _httpContextAccessor;

  public CreatePointLabelCommand(
      IPointLabelRepository repository,
      IAccessValidator accessValidator,
      IHttpContextAccessor httpContextAccessor)
  {
    _repository = repository;
    _accessValidator = accessValidator;
    _httpContextAccessor = httpContextAccessor;
  }

  public async Task<OperationResultResponse<Guid?>> ExecuteAsync(CreatePointLabelRequest request)
  {
    if (!await _accessValidator.IsAdminAsync() && !await _accessValidator.IsModeratorAsync())
    {
      return new OperationResultResponse<Guid?>
      {
        StatusCode = HttpStatusCode.Forbidden,
        Message = "Only admins or moderators can create labels."
      };
    }

    var label = new DbPointLabel
    {
      Id = Guid.NewGuid(),
      Name = JsonSerializer.Serialize(request.Name),
      CreatedBy = _httpContextAccessor.HttpContext.GetUserId(),
      CreatedAtUtc = DateTime.UtcNow,
      IsActive = true
    };

    await _repository.CreateAsync(label);
    return new OperationResultResponse<Guid?>
    {
      Body = label.Id
    };
  }
}