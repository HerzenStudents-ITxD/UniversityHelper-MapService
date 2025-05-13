using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Relation.Interfaces;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Controllers;

[ApiController]
[Route("[controller]")]
public class RelationController : ControllerBase
{
  private readonly IBuildRelationCommand _buildRelationCommand;
  private readonly IGetAvailableRelationsCommand _getAvailableRelationsCommand;
  private readonly ICreateRelationCommand _createRelationCommand;
  private readonly IEditRelationCommand _editRelationCommand;
  private readonly IDeleteRelationCommand _deleteRelationCommand;

  public RelationController(
      IBuildRelationCommand buildRelationCommand,
      IGetAvailableRelationsCommand getAvailableRoutesCommand,
      ICreateRelationCommand createRelationCommand,
      IEditRelationCommand editRelationCommand,
      IDeleteRelationCommand deleteRelationCommand)
  {
    _buildRelationCommand = buildRelationCommand;
    _getAvailableRelationsCommand = getAvailableRoutesCommand;
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
    return await _buildRelationCommand.ExecuteAsync(new BuildRelationFilter { StartPointId = startPointId, EndPointId = endPointId, Locale = locale });
  }

  [HttpGet("available")]
  public async Task<OperationResultResponse<List<PointInfo>>> Available(
      [FromQuery] Guid pointId,
      [FromQuery] string locale)
  {
    return await _getAvailableRelationsCommand.ExecuteAsync(new AvailableRelationsFilter { PointId = pointId, Locale = locale });
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