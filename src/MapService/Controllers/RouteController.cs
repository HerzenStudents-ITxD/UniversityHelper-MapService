using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Route.Interfaces;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Controllers;

[ApiController]
[Route("[controller]")]
public class RouteController : ControllerBase
{
  private readonly IBuildRouteCommand _buildRouteCommand;
  private readonly IGetAvailableRoutesCommand _getAvailableRoutesCommand;
  private readonly ICreateRelationCommand _createRelationCommand;
  private readonly IEditRelationCommand _editRelationCommand;
  private readonly IDeleteRelationCommand _deleteRelationCommand;

  public RouteController(
      IBuildRouteCommand buildRouteCommand,
      IGetAvailableRoutesCommand getAvailableRoutesCommand,
      ICreateRelationCommand createRelationCommand,
      IEditRelationCommand editRelationCommand,
      IDeleteRelationCommand deleteRelationCommand)
  {
    _buildRouteCommand = buildRouteCommand;
    _getAvailableRoutesCommand = getAvailableRoutesCommand;
    _createRelationCommand = createRelationCommand;
    _editRelationCommand = editRelationCommand;
    _deleteRelationCommand = deleteRelationCommand;
  }

  [HttpGet("build")]
  public async Task<OperationResultResponse<List<PointInfo>>> Build(
      [FromQuery] Guid startPointId,
      [FromQuery] Guid endPointId,
      [FromQuery] string locale)
  {
    return await _buildRouteCommand.ExecuteAsync(new BuildRouteFilter { StartPointId = startPointId, EndPointId = endPointId, Locale = locale });
  }

  [HttpGet("available")]
  public async Task<OperationResultResponse<List<PointInfo>>> Available(
      [FromQuery] Guid pointId,
      [FromQuery] string locale)
  {
    return await _getAvailableRoutesCommand.ExecuteAsync(new AvailableRoutesFilter { PointId = pointId, Locale = locale });
  }

  [HttpPost("create")]
  public async Task<OperationResultResponse<Guid?>> Create(
      [FromBody] CreateRelationRequest request)
  {
    return await _createRelationCommand.ExecuteAsync(request);
  }

  [HttpPut("edit/{relationId}")]
  public async Task<OperationResultResponse<bool>> Edit(
      Guid relationId,
      [FromBody] EditRelationRequest request)
  {
    return await _editRelationCommand.ExecuteAsync(relationId, request);
  }

  [HttpDelete("{relationId}")]
  public async Task<OperationResultResponse<bool>> Delete(
      Guid relationId)
  {
    return await _deleteRelationCommand.ExecuteAsync(relationId);
  }
}