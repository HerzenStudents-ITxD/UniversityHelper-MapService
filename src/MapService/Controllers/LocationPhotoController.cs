using HerzenHelper.Core.Responses;
using HerzenHelper.MapService.Business.Commands.Right.Interfaces;
using HerzenHelper.MapService.Models.Dto.Models;
using HerzenHelper.MapService.Models.Dto.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HerzenHelper.MapService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationPhotoController : ControllerBase
    {
        //[HttpGet("get")]
        //public async Task<OperationResultResponse<List<LocationPhotoInfo>>> Get(
        //    [FromQuery] Guid locationId,
        //    [FromServices] IGetLocationPhotoListCommand command)
        //{
        //    return await command.ExecuteAsync(locationId);
        //}

        //[HttpPost("create")]
        //public async Task<OperationResultResponse<Guid?>> Post(
        //    [FromBody] CreateLocationPhotoRequest request,
        //    [FromServices] ICreateLocationPhotoCommand command)
        //{
        //    return await command.ExecuteAsync(request);
        //}

        //[HttpPut("edit")]
        //public async Task<OperationResultResponse<Guid?>> Post(
        //    [FromBody] EditLocationPhotoRequest request,
        //    [FromServices] IEditLocationPhotoCommand command)
        //{
        //    return await command.ExecuteAsync(request);
        //}
    }
}
