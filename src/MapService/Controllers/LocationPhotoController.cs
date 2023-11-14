using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Right.Interfaces;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests;
using Microsoft.AspNetCore.Mvc;

namespace UniversityHelper.MapService.Controllers;

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
