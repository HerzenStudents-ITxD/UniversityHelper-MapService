using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Location.Interfaces;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Controllers;

[ApiController]
[Route("[controller]")]
public class PointController : ControllerBase
{
  private readonly IFindPointsCommand _findPointsCommand;
  private readonly IGetPointCommand _getPointCommand;
  private readonly ICreatePointCommand _createPointCommand;
  private readonly IEditPointCommand _editPointCommand;
  private readonly IDeletePointCommand _deletePointCommand;

  public PointController(
      IFindPointsCommand findPointsCommand,
      IGetPointCommand getPointCommand,
      ICreatePointCommand createPointCommand,
      IEditPointCommand editPointCommand,
      IDeletePointCommand deletePointCommand)
  {
    _findPointsCommand = findPointsCommand;
    _getPointCommand = getPointCommand;
    _createPointCommand = createPointCommand;
    _editPointCommand = editPointCommand;
    _deletePointCommand = deletePointCommand;
  }

  [HttpGet("find")]
  public async Task<OperationResultResponse<List<PointInfo>>> Find(
      [FromQuery] FindPointsFilter filter)
  {
    return await _findPointsCommand.ExecuteAsync(filter);
  }

  [HttpGet("{pointId}")]
  public async Task<OperationResultResponse<PointInfo>> Get(
      Guid pointId,
      [FromQuery] string locale)
  {
    return await _getPointCommand.ExecuteAsync(new GetPointFilter { PointId = pointId, Locale = locale });
  }

  [HttpPost("create")]
  public async Task<OperationResultResponse<Guid?>> Create(
      [FromBody] CreatePointRequest request)
  {
    return await _createPointCommand.ExecuteAsync(request);
  }

  [HttpPut("edit/{pointId}")]
  public async Task<OperationResultResponse<bool>> Edit(
      Guid pointId,
      [FromBody] EditPointRequest request)
  {
    return await _editPointCommand.ExecuteAsync(pointId, request);
  }

  [HttpDelete("{pointId}")]
  public async Task<OperationResultResponse<bool>> Delete(
      Guid pointId)
  {
    return await _deletePointCommand.ExecuteAsync(pointId);
  }
}