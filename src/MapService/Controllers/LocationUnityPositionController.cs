using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Right.Interfaces;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests;
using Microsoft.AspNetCore.Mvc;

namespace UniversityHelper.MapService.Controllers;

[ApiController]
[Route("[controller]")]
public class PointUnityPositionController : ControllerBase
{
  //[HttpGet("get")]
  //public async Task<OperationResultResponse<List<PointUnityPositionInfo>>> Get(
  //    [FromServices] IGetPointUnityPositionListCommand command)
  //{
  //    return await command.ExecuteAsync();
  //}

  //[HttpPost("create")]
  //public async Task<OperationResultResponse<Guid?>> Post(
  //    [FromBody] CreatePointUnityPositionRequest request,
  //    [FromServices] ICreatePointUnityPositionCommand command)
  //{
  //    return await command.ExecuteAsync(request);
  //}

  //[HttpPut("edit")]
  //public async Task<OperationResultResponse<bool>> Edit(
  //    [FromBody] EditPointUnityPositionRequest request,
  //    [FromServices] IEditPointUnityPositionCommand command)
  //{
  //    return await command.ExecuteAsync(request);
  //}
}
