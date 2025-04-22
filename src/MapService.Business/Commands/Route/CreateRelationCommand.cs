using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Extensions;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Route.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Business.Commands.Route;

public class CreateRelationCommand : ICreateRelationCommand
{
  private readonly IRelationRepository _relationRepository;
  private readonly IPointRepository _pointRepository;
  private readonly IAccessValidator _accessValidator;
  private readonly IHttpContextAccessor _httpContextAccessor;

  public CreateRelationCommand(
      IRelationRepository relationRepository,
      IPointRepository pointRepository,
      IAccessValidator accessValidator,
      IHttpContextAccessor httpContextAccessor)
  {
    _relationRepository = relationRepository;
    _pointRepository = pointRepository;
    _accessValidator = accessValidator;
    _httpContextAccessor = httpContextAccessor;
  }

  public async Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateRelationRequest request)
  {
    if (!await _accessValidator.IsAdminAsync() && !await _accessValidator.IsModeratorAsync())
    {
      return new OperationResultResponse<Guid?>
      {
        StatusCode = HttpStatusCode.Forbidden,
        Message = "Only admins or moderators can create relations."
      };
    }

    if (!await _pointRepository.DoesExistAsync(request.FirstPointId) || !await _pointRepository.DoesExistAsync(request.SecondPointId))
    {
      return new OperationResultResponse<Guid?>
      {
        StatusCode = HttpStatusCode.NotFound,
        Message = "One or both points not found."
      };
    }

    var relation = new DbRelation
    {
      Id = Guid.NewGuid(),
      FirstPointId = request.FirstPointId,
      SecondPointId = request.SecondPointId,
      CreatedBy = _httpContextAccessor.HttpContext.GetUserId(),
      CreatedAtUtc = DateTime.UtcNow
    };

    await _relationRepository.CreateAsync(relation);
    return new OperationResultResponse<Guid?>
    {
      Body = relation.Id
    };
  }
}