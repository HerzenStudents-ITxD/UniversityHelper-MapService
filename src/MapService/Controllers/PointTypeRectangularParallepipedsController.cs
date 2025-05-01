using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.PointTypeRectangularParallepiped.Interfaces;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Controllers;

[ApiController]
[Route("[controller]")]
public class PointTypeRectangularParallepipedsController : ControllerBase
{
  private readonly IGetPointTypeRectangularParallepipedsCommand _getPointTypeRectangularParallepipedsCommand;
  private readonly ICreatePointTypeRectangularParallepipedCommand _createPointTypeRectangularParallepipedCommand;
  private readonly IEditPointTypeRectangularParallepipedCommand _editPointTypeRectangularParallepipedCommand;
  private readonly IDeletePointTypeRectangularParallepipedCommand _deletePointTypeRectangularParallepipedCommand;

  public PointTypeRectangularParallepipedsController(
      IGetPointTypeRectangularParallepipedsCommand getPointTypeRectangularParallepipedsCommand,
      ICreatePointTypeRectangularParallepipedCommand createPointTypeRectangularParallepipedCommand,
      IEditPointTypeRectangularParallepipedCommand editPointTypeRectangularParallepipedCommand,
      IDeletePointTypeRectangularParallepipedCommand deletePointTypeRectangularParallepipedCommand)
  {
    _getPointTypeRectangularParallepipedsCommand = getPointTypeRectangularParallepipedsCommand;
    _createPointTypeRectangularParallepipedCommand = createPointTypeRectangularParallepipedCommand;
    _editPointTypeRectangularParallepipedCommand = editPointTypeRectangularParallepipedCommand;
    _deletePointTypeRectangularParallepipedCommand = deletePointTypeRectangularParallepipedCommand;
  }

  [HttpGet("list/{pointTypeId}")]
  public async Task<OperationResultResponse<List<PointTypeRectangularParallepipedInfo>>> List(
      Guid pointTypeId)
  {
    return await _getPointTypeRectangularParallepipedsCommand.ExecuteAsync(new GetPointTypeRectangularParallepipedsFilter { PointTypeId = pointTypeId });
  }

  [HttpPost("create")]
  public async Task<OperationResultResponse<Guid?>> Create(
      [FromBody] CreatePointTypeRectangularParallepipedRequest request)
  {
    return await _createPointTypeRectangularParallepipedCommand.ExecuteAsync(request);
  }

  [HttpPut("edit/{parallelepipedId}")]
  public async Task<OperationResultResponse<bool>> Edit(
      Guid parallelepipedId,
      [FromBody] EditPointTypeRectangularParallepipedRequest request)
  {
    return await _editPointTypeRectangularParallepipedCommand.ExecuteAsync(parallelepipedId, request);
  }

  [HttpDelete("{parallelepipedId}")]
  public async Task<OperationResultResponse<bool>> Delete(
      Guid parallelepipedId)
  {
    return await _deletePointTypeRectangularParallepipedCommand.ExecuteAsync(parallelepipedId);
  }
}