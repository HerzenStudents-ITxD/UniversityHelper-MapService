using HerzenHelper.Core.Responses;
using HerzenHelper.MapService.Business.Commands.Right.Interfaces;
using HerzenHelper.MapService.Models.Dto.Models;
using HerzenHelper.MapService.Models.Dto.Requests;
using HerzenHelper.MapService.Models.Dto.Requests.Filters;
using Microsoft.AspNetCore.Mvc;

namespace HerzenHelper.MapService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        [HttpGet("find")]
        public async Task<OperationResultResponse<List<LocationInfo>>> Get(
            [FromServices] IFindLocationsCommand command,
            [FromQuery] FindLocationsFilter filter)
        {
            return await command.ExecuteAsync(filter);
        }

        //[HttpPost("create")]
        //public async Task<OperationResultResponse<Guid?>> Post(
        //    [FromBody] CreateLocationRequest request,
        //    [FromServices] ICreateLocationCommand command)
        //{
        //    return await command.ExecuteAsync(request);
        //}

        //[HttpPut("edit")]
        //public async Task<OperationResultResponse<bool>> Edit(
        //    [FromBody] EditLocationRequest request,
        //    [FromServices] IEditLocationCommand command)
        //{
        //    return await command.ExecuteAsync(request);
        //}
    }
}
