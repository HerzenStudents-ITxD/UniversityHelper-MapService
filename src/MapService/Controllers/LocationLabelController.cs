using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Right.Interfaces;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests;
using Microsoft.AspNetCore.Mvc;

namespace UniversityHelper.MapService.Controllers;

[ApiController]
[Route("[controller]")]
public class PointLabelController : ControllerBase
{
  //[HttpGet("get")]
  //public async Task<OperationResultResponse<List<PointLabelInfo>>> Get(
  //    [FromQuery] Guid pointId,
  //    [FromServices] IGetPointLabelListCommand command)
  //{
  //    return await command.ExecuteAsync(pointId);
  //}


  //[HttpPost("create")]
  //public async Task<OperationResultResponse<Guid?>> Post(
  //    [FromBody] CreatePointLabelRequest request,
  //    [FromServices] ICreatePointLabelCommand command)
  //{
  //    return await command.ExecuteAsync(request);
  //}

  //[HttpPut("edit")]
  //public async Task<OperationResultResponse<bool>> Edit(
  //    [FromBody] EditPointLabelRequest request,
  //    [FromServices] IEditPointLabelCommand command)
  //{
  //    return await command.ExecuteAsync(request);
  //}
}
