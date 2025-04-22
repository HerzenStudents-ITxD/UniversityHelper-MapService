using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Photo.Interfaces;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Controllers;

[ApiController]
[Route("[controller]")]
public class PointPhotoController : ControllerBase
{
  private readonly IGetPointPhotosCommand _getPointPhotosCommand;
  private readonly ICreatePointPhotoCommand _createPointPhotoCommand;
  private readonly IEditPointPhotoCommand _editPointPhotoCommand;
  private readonly IDeletePointPhotoCommand _deletePointPhotoCommand;

  public PointPhotoController(
      IGetPointPhotosCommand getPointPhotosCommand,
      ICreatePointPhotoCommand createPointPhotoCommand,
      IEditPointPhotoCommand editPointPhotoCommand,
      IDeletePointPhotoCommand deletePointPhotoCommand)
  {
    _getPointPhotosCommand = getPointPhotosCommand;
    _createPointPhotoCommand = createPointPhotoCommand;
    _editPointPhotoCommand = editPointPhotoCommand;
    _deletePointPhotoCommand = deletePointPhotoCommand;
  }

  [HttpGet("list/{pointId}")]
  public async Task<OperationResultResponse<List<PointPhotoInfo>>> List(
      Guid pointId)
  {
    return await _getPointPhotosCommand.ExecuteAsync(new GetPointPhotosFilter { PointId = pointId });
  }

  [HttpPost("create")]
  public async Task<OperationResultResponse<Guid?>> Create(
      [FromBody] CreatePointPhotoRequest request)
  {
    return await _createPointPhotoCommand.ExecuteAsync(request);
  }

  [HttpPut("edit/{photoId}")]
  public async Task<OperationResultResponse<bool>> Edit(
      Guid photoId,
      [FromBody] EditPointPhotoRequest request)
  {
    return await _editPointPhotoCommand.ExecuteAsync(photoId, request);
  }

  [HttpDelete("{photoId}")]
  public async Task<OperationResultResponse<bool>> Delete(
      Guid photoId)
  {
    return await _deletePointPhotoCommand.ExecuteAsync(photoId);
  }
}