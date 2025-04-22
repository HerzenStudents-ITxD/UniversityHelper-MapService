using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Location.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Mappers.Models.Interfaces;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Business.Commands.Location;

public class GetPointCommand : IGetPointCommand
{
  private readonly IPointRepository _repository;
  private readonly IPointInfoMapper _mapper;

  public GetPointCommand(
      IPointRepository repository,
      IPointInfoMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  public async Task<OperationResultResponse<PointInfo>> ExecuteAsync(GetPointFilter filter)
  {
    var point = await _repository.GetAsync(filter);
    if (point == null)
    {
      return new OperationResultResponse<PointInfo>
      {
        StatusCode = HttpStatusCode.NotFound,
        Message = "Point not found."
      };
    }

    return new OperationResultResponse<PointInfo>
    {
      Body = _mapper.Map(point)
    };
  }
}