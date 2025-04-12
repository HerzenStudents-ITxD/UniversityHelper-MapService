using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Right.Interfaces;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests;
using Microsoft.AspNetCore.Mvc;

namespace UniversityHelper.MapService.Controllers;

[ApiController]
[Route("[controller]")]
public class PointUnityObjectNameController : ControllerBase
{
  //[HttpGet("get")]
  //public async Task<OperationResultResponse<List<PointUnityObjectNameInfo>>> Get(
  //    [FromServices] IGetPointUnityObjectNameListCommand command)
  //{
  //    return await command.ExecuteAsync();
  //}

  //[HttpPost("create")]
  //public async Task<OperationResultResponse<Guid?>> Post(
  //    [FromBody] CreatePointUnityObjectNameRequest request,
  //    [FromServices] ICreatePointUnityObjectNameCommand command)
  //{
  //    return await command.ExecuteAsync(request);
  //}

  //[HttpPut("edit")]
  //public async Task<OperationResultResponse<bool>> Edit(
  //    [FromBody] EditPointUnityObjectNameRequest request,
  //    [FromServices] IEditPointUnityObjectNameCommand command)
  //{
  //    return await command.ExecuteAsync(request);
  //}
}
