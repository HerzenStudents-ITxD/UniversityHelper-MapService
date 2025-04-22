using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Label.Interfaces;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Controllers;

[ApiController]
[Route("[controller]")]
public class PointLabelController : ControllerBase
{
  private readonly IGetPointLabelsCommand _getPointLabelsCommand;
  private readonly ICreatePointLabelCommand _createPointLabelCommand;
  private readonly IEditPointLabelCommand _editPointLabelCommand;
  private readonly IDeletePointLabelCommand _deletePointLabelCommand;

  public PointLabelController(
      IGetPointLabelsCommand getPointLabelsCommand,
      ICreatePointLabelCommand createPointLabelCommand,
      IEditPointLabelCommand editPointLabelCommand,
      IDeletePointLabelCommand deletePointLabelCommand)
  {
    _getPointLabelsCommand = getPointLabelsCommand;
    _createPointLabelCommand = createPointLabelCommand;
    _editPointLabelCommand = editPointLabelCommand;
    _deletePointLabelCommand = deletePointLabelCommand;
  }

  [HttpGet("list")]
  public async Task<OperationResultResponse<List<PointLabelInfo>>> List(
      [FromQuery] string? locale)
  {
    return await _getPointLabelsCommand.ExecuteAsync(new GetPointLabelsFilter { Locale = locale });
  }

  [HttpPost("create")]
  public async Task<OperationResultResponse<Guid?>> Create(
      [FromBody] CreatePointLabelRequest request)
  {
    return await _createPointLabelCommand.ExecuteAsync(request);
  }

  [HttpPut("edit/{labelId}")]
  public async Task<OperationResultResponse<bool>> Edit(
      Guid labelId,
      [FromBody] EditPointLabelRequest request)
  {
    return await _editPointLabelCommand.ExecuteAsync(labelId, request);
  }

  [HttpDelete("{labelId}")]
  public async Task<OperationResultResponse<bool>> Delete(
      Guid labelId)
  {
    return await _deletePointLabelCommand.ExecuteAsync(labelId);
  }
}