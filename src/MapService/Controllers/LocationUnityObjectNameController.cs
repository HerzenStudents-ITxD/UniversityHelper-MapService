﻿using HerzenHelper.Core.Responses;
using HerzenHelper.MapService.Business.Commands.Right.Interfaces;
using HerzenHelper.MapService.Models.Dto.Models;
using HerzenHelper.MapService.Models.Dto.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HerzenHelper.MapService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationUnityObjectNameController : ControllerBase
    {
        //[HttpGet("get")]
        //public async Task<OperationResultResponse<List<LocationUnityObjectNameInfo>>> Get(
        //    [FromServices] IGetLocationUnityObjectNameListCommand command)
        //{
        //    return await command.ExecuteAsync();
        //}

        //[HttpPost("create")]
        //public async Task<OperationResultResponse<Guid?>> Post(
        //    [FromBody] CreateLocationUnityObjectNameRequest request,
        //    [FromServices] ICreateLocationUnityObjectNameCommand command)
        //{
        //    return await command.ExecuteAsync(request);
        //}

        //[HttpPut("edit")]
        //public async Task<OperationResultResponse<bool>> Edit(
        //    [FromBody] EditLocationUnityObjectNameRequest request,
        //    [FromServices] IEditLocationUnityObjectNameCommand command)
        //{
        //    return await command.ExecuteAsync(request);
        //}
    }
}
