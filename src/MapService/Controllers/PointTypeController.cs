using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.PointType.Interfaces;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Controllers;

[ApiController]
[Route("[controller]")]
public class PointTypeController : ControllerBase
{
  private readonly IGetPointTypesCommand _getPointTypesCommand;
  private readonly ICreatePointTypeCommand _createPointTypeCommand;
  private readonly IEditPointTypeCommand _editPointTypeCommand;
  private readonly IDeletePointTypeCommand _deletePointTypeCommand;

  public PointTypeController(
      IGetPointTypesCommand getPointTypesCommand,
      ICreatePointTypeCommand createPointTypeCommand,
      IEditPointTypeCommand editPointTypeCommand,
      IDeletePointTypeCommand deletePointTypeCommand)
  {
    _getPointTypesCommand = getPointTypesCommand;
    _createPointTypeCommand = createPointTypeCommand;
    _editPointTypeCommand = editPointTypeCommand;
    _deletePointTypeCommand = deletePointTypeCommand;
  }

  [HttpGet("list")]
  public async Task<OperationResultResponse<List<PointTypeInfo>>> List(
      [FromQuery] string? locale)
  {
    return await _getPointTypesCommand.ExecuteAsync(new GetPointTypesFilter { Locale = locale });
  }

  [HttpPost("create")]
  public async Task<OperationResultResponse<Guid?>> Create(
      [FromBody] CreatePointTypeRequest request)
  {
    return await _createPointTypeCommand.ExecuteAsync(request);
  }

  [HttpPut("edit/{typeId}")]
  public async Task<OperationResultResponse<bool>> Edit(
      Guid typeId,
      [FromBody] EditPointTypeRequest request)
  {
    return await _editPointTypeCommand.ExecuteAsync(typeId, request);
  }

  [HttpDelete("{typeId}")]
  public async Task<OperationResultResponse<bool>> Delete(
      Guid typeId)
  {
    return await _deletePointTypeCommand.ExecuteAsync(typeId);
  }
}