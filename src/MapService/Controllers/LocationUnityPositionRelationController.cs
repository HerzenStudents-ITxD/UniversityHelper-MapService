using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Right.Interfaces;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests;
using Microsoft.AspNetCore.Mvc;

namespace UniversityHelper.MapService.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationUnityPositionRelationController : ControllerBase
{
  //[HttpGet("get")]
  //public async Task<OperationResultResponse<List<RelationInfo>>> Get(
  //    [FromServices] IGetRelationListCommand command)
  //{
  //    return await command.ExecuteAsync();
  //}

  //[HttpPost("create")]
  //public async Task<OperationResultResponse<Guid?>> Post(
  //    [FromBody] CreateRelationRequest request,
  //    [FromServices] ICreateRelationCommand command)
  //{
  //    return await command.ExecuteAsync(request);
  //}

  //[HttpPut("edit")]
  //public async Task<OperationResultResponse<bool>> Edit(
  //    [FromBody] EditRelationRequest request,
  //    [FromServices] IEditRelationCommand command)
  //{
  //    return await command.ExecuteAsync(request);
  //}
}
