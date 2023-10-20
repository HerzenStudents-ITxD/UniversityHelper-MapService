using HerzenHelper.Core.Responses;
using HerzenHelper.MapService.Business.Commands.Right.Interfaces;
using HerzenHelper.MapService.Models.Dto.Models;
using HerzenHelper.MapService.Models.Dto.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HerzenHelper.MapService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelationController : ControllerBase
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
}
