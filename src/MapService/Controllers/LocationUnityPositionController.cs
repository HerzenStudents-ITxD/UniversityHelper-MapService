﻿using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Right.Interfaces;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests;
using Microsoft.AspNetCore.Mvc;

namespace UniversityHelper.MapService.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationUnityPositionController : ControllerBase
{
  //[HttpGet("get")]
  //public async Task<OperationResultResponse<List<LocationUnityPositionInfo>>> Get(
  //    [FromServices] IGetLocationUnityPositionListCommand command)
  //{
  //    return await command.ExecuteAsync();
  //}

  //[HttpPost("create")]
  //public async Task<OperationResultResponse<Guid?>> Post(
  //    [FromBody] CreateLocationUnityPositionRequest request,
  //    [FromServices] ICreateLocationUnityPositionCommand command)
  //{
  //    return await command.ExecuteAsync(request);
  //}

  //[HttpPut("edit")]
  //public async Task<OperationResultResponse<bool>> Edit(
  //    [FromBody] EditLocationUnityPositionRequest request,
  //    [FromServices] IEditLocationUnityPositionCommand command)
  //{
  //    return await command.ExecuteAsync(request);
  //}
}
