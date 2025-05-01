using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.PointTypeAssociation.Interfaces;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Controllers;

[ApiController]
[Route("[controller]")]
public class PointTypeAssociationController : ControllerBase
{
  private readonly IGetPointTypeAssociationsCommand _getPointTypeAssociationsCommand;
  private readonly ICreatePointTypeAssociationCommand _createPointTypeAssociationCommand;
  private readonly IEditPointTypeAssociationCommand _editPointTypeAssociationCommand;
  private readonly IDeletePointTypeAssociationCommand _deletePointTypeAssociationCommand;

  public PointTypeAssociationController(
      IGetPointTypeAssociationsCommand getPointTypeAssociationsCommand,
      ICreatePointTypeAssociationCommand createPointTypeAssociationCommand,
      IEditPointTypeAssociationCommand editPointTypeAssociationCommand,
      IDeletePointTypeAssociationCommand deletePointTypeAssociationCommand)
  {
    _getPointTypeAssociationsCommand = getPointTypeAssociationsCommand;
    _createPointTypeAssociationCommand = createPointTypeAssociationCommand;
    _editPointTypeAssociationCommand = editPointTypeAssociationCommand;
    _deletePointTypeAssociationCommand = deletePointTypeAssociationCommand;
  }

  [HttpGet("list/{pointTypeId}")]
  public async Task<OperationResultResponse<List<PointTypeAssociationInfo>>> List(
      Guid pointTypeId)
  {
    return await _getPointTypeAssociationsCommand.ExecuteAsync(new GetPointTypeAssociationsFilter { PointTypeId = pointTypeId });
  }

  [HttpPost("create")]
  public async Task<OperationResultResponse<Guid?>> Create(
      [FromBody] CreatePointTypeAssociationRequest request)
  {
    return await _createPointTypeAssociationCommand.ExecuteAsync(request);
  }

  [HttpPut("edit/{associationId}")]
  public async Task<OperationResultResponse<bool>> Edit(
      Guid associationId,
      [FromBody] EditPointTypeAssociationRequest request)
  {
    return await _editPointTypeAssociationCommand.ExecuteAsync(associationId, request);
  }

  [HttpDelete("{associationId}")]
  public async Task<OperationResultResponse<bool>> Delete(
      Guid associationId)
  {
    return await _deletePointTypeAssociationCommand.ExecuteAsync(associationId);
  }
}