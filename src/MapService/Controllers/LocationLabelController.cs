using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Right.Interfaces;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests;
using Microsoft.AspNetCore.Mvc;

namespace UniversityHelper.MapService.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationLabelController : ControllerBase
{
  //[HttpGet("get")]
  //public async Task<OperationResultResponse<List<LocationLabelInfo>>> Get(
  //    [FromQuery] Guid locationId,
  //    [FromServices] IGetLocationLabelListCommand command)
  //{
  //    return await command.ExecuteAsync(locationId);
  //}


  //[HttpPost("create")]
  //public async Task<OperationResultResponse<Guid?>> Post(
  //    [FromBody] CreateLocationLabelRequest request,
  //    [FromServices] ICreateLocationLabelCommand command)
  //{
  //    return await command.ExecuteAsync(request);
  //}

  //[HttpPut("edit")]
  //public async Task<OperationResultResponse<bool>> Edit(
  //    [FromBody] EditLocationLabelRequest request,
  //    [FromServices] IEditLocationLabelCommand command)
  //{
  //    return await command.ExecuteAsync(request);
  //}
}
