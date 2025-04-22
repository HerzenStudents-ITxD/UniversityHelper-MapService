using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Route.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Mappers.Models.Interfaces;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Business.Commands.Route;

public class GetAvailableRoutesCommand : IGetAvailableRoutesCommand
{
  private readonly IRelationRepository _relationRepository;
  private readonly IPointRepository _pointRepository;
  private readonly IRouteInfoMapper _mapper;

  public GetAvailableRoutesCommand(
      IRelationRepository relationRepository,
      IPointRepository pointRepository,
      IRouteInfoMapper mapper)
  {
    _relationRepository = relationRepository;
    _pointRepository = pointRepository;
    _mapper = mapper;
  }

  public async Task<OperationResultResponse<List<PointInfo>>> ExecuteAsync(AvailableRoutesFilter filter)
  {
    if (!await _pointRepository.DoesExistAsync(filter.PointId))
    {
      return new OperationResultResponse<List<PointInfo>>
      {
        StatusCode = HttpStatusCode.NotFound,
        Message = "Point not found."
      };
    }

    var relations = await _relationRepository.GetByPointAsync(filter.PointId);
    var pointIds = relations.Select(r => r.FirstPointId == filter.PointId ? r.SecondPointId : r.FirstPointId).Distinct().ToList();
    var points = new List<DbPoint>();

    foreach (var pointId in pointIds)
    {
      var point = await _pointRepository.GetAsync(new GetPointFilter { PointId = pointId, Locale = filter.Locale });
      if (point != null)
      {
        points.Add(point);
      }
    }

    return new OperationResultResponse<List<PointInfo>>
    {
      Body = _mapper.Map(points)
    };
  }
}