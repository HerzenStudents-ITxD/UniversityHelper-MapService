using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Right.Interfaces;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;
using Microsoft.AspNetCore.Mvc;

namespace UniversityHelper.MapService.Controllers;

[ApiController]
[Route("[controller]")]
public class PointController : ControllerBase
{
  [HttpGet("find")]
  public async Task<OperationResultResponse<List<PointInfo>>> Get(
      [FromServices] IFindPointsCommand command,
      [FromQuery] FindPointsFilter filter)
  {
    return await command.ExecuteAsync(filter);
  }

  //[HttpPost("create")]
  //public async Task<OperationResultResponse<Guid?>> Post(
  //    [FromBody] CreatePointRequest request,
  //    [FromServices] ICreatePointCommand command)
  //{
  //    return await command.ExecuteAsync(request);
  //}

  //[HttpPut("edit")]
  //public async Task<OperationResultResponse<bool>> Edit(
  //    [FromBody] EditPointRequest request,
  //    [FromServices] IEditPointCommand command)
  //{
  //    return await command.ExecuteAsync(request);
  //}
}
