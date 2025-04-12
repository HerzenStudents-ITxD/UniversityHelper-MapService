using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Right.Interfaces;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests;
using Microsoft.AspNetCore.Mvc;

namespace UniversityHelper.MapService.Controllers;

[ApiController]
[Route("[controller]")]
public class PointPhotoController : ControllerBase
{
  //[HttpGet("get")]
  //public async Task<OperationResultResponse<List<PointPhotoInfo>>> Get(
  //    [FromQuery] Guid pointId,
  //    [FromServices] IGetPointPhotoListCommand command)
  //{
  //    return await command.ExecuteAsync(pointId);
  //}

  //[HttpPost("create")]
  //public async Task<OperationResultResponse<Guid?>> Post(
  //    [FromBody] CreatePointPhotoRequest request,
  //    [FromServices] ICreatePointPhotoCommand command)
  //{
  //    return await command.ExecuteAsync(request);
  //}

  //[HttpPut("edit")]
  //public async Task<OperationResultResponse<Guid?>> Post(
  //    [FromBody] EditPointPhotoRequest request,
  //    [FromServices] IEditPointPhotoCommand command)
  //{
  //    return await command.ExecuteAsync(request);
  //}
}
