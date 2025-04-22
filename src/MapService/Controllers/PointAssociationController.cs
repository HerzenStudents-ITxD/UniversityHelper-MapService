using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Association.Interfaces;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Controllers;

[ApiController]
[Route("[controller]")]
public class PointAssociationController : ControllerBase
{
  private readonly IGetPointAssociationsCommand _getPointAssociationsCommand;
  private readonly ICreatePointAssociationCommand _createPointAssociationCommand;
  private readonly IEditPointAssociationCommand _editPointAssociationCommand;
  private readonly IDeletePointAssociationCommand _deletePointAssociationCommand;

  public PointAssociationController(
      IGetPointAssociationsCommand getPointAssociationsCommand,
      ICreatePointAssociationCommand createPointAssociationCommand,
      IEditPointAssociationCommand editPointAssociationCommand,
      IDeletePointAssociationCommand deletePointAssociationCommand)
  {
    _getPointAssociationsCommand = getPointAssociationsCommand;
    _createPointAssociationCommand = createPointAssociationCommand;
    _editPointAssociationCommand = editPointAssociationCommand;
    _deletePointAssociationCommand = deletePointAssociationCommand;
  }

  [HttpGet("list")]
  public async Task<OperationResultResponse<List<PointAssociationInfo>>> List()
  {
    return await _getPointAssociationsCommand.ExecuteAsync(new GetPointAssociationsFilter());
  }

  [HttpPost("create")]
  public async Task<OperationResultResponse<Guid?>> Create(
      [FromBody] CreatePointAssociationRequest request)
  {
    return await _createPointAssociationCommand.ExecuteAsync(request);
  }

  [HttpPut("edit/{associationId}")]
  public async Task<OperationResultResponse<bool>> Edit(
      Guid associationId,
      [FromBody] EditPointAssociationRequest request)
  {
    return await _editPointAssociationCommand.ExecuteAsync(associationId, request);
  }

  [HttpDelete("{associationId}")]
  public async Task<OperationResultResponse<bool>> Delete(
      Guid associationId)
  {
    return await _deletePointAssociationCommand.ExecuteAsync(associationId);
  }
}