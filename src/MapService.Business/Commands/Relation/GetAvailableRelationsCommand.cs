using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Relation.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Mappers.Models.Interfaces;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Business.Commands.Relation;

public class GetAvailableRelationsCommand : IGetAvailableRelationsCommand
{
  private readonly IRelationRepository _relationRepository;
  private readonly IPointRepository _pointRepository;
  private readonly IRelationInfoMapper _mapper;

  public GetAvailableRelationsCommand(
      IRelationRepository relationRepository,
      IPointRepository pointRepository,
      IRelationInfoMapper mapper)
  {
    _relationRepository = relationRepository;
    _pointRepository = pointRepository;
    _mapper = mapper;
  }

  public async Task<OperationResultResponse<List<PointInfo>>> ExecuteAsync(AvailableRelationsFilter filter)
  {
    if (!await _pointRepository.DoesExistAsync(filter.PointId))
    {
      return new OperationResultResponse<List<PointInfo>>
      (
            body: null,
        errors: new List<string> { "Point not found." }
      );
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