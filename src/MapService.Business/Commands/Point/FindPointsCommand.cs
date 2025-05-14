using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Point.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Mappers.Models.Interfaces;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Business.Commands.Point;

public class FindPointsCommand : IFindPointsCommand
{
  private readonly IPointRepository _repository;
  private readonly IPointInfoMapper _mapper;
  private readonly IAccessValidator _accessValidator;

  public FindPointsCommand(
      IPointRepository repository,
      IPointInfoMapper mapper,
      IAccessValidator accessValidator)
  {
    _repository = repository;
    _mapper = mapper;
    _accessValidator = accessValidator;
  }

  public async Task<OperationResultResponse<List<PointInfo>>> ExecuteAsync(FindPointsFilter filter)
  {

    var points = await _repository.FindAllAsync(filter);
    return new OperationResultResponse<List<PointInfo>>
    {
      Body = points.Select(_mapper.Map).ToList()
    };
  }
}