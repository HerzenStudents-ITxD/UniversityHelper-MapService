using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.PointTypeRectangularParallepiped.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Mappers.Models.Interfaces;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Business.Commands.PointTypeRectangularParallepiped;

public class GetPointTypeRectangularParallepipedsCommand : IGetPointTypeRectangularParallepipedsCommand
{
  private readonly IPointTypeRectangularParallepipedRepository _parallelepipedRepository;
  private readonly IPointTypeRepository _pointTypeRepository;
  private readonly IPointTypeRectangularParallepipedInfoMapper _mapper;
  private readonly IAccessValidator _accessValidator;

  public GetPointTypeRectangularParallepipedsCommand(
      IPointTypeRectangularParallepipedRepository parallelepipedRepository,
      IPointTypeRepository pointTypeRepository,
      IPointTypeRectangularParallepipedInfoMapper mapper,
      IAccessValidator accessValidator)
  {
    _parallelepipedRepository = parallelepipedRepository;
    _pointTypeRepository = pointTypeRepository;
    _mapper = mapper;
    _accessValidator = accessValidator;
  }

  public async Task<OperationResultResponse<List<PointTypeRectangularParallepipedInfo>>> ExecuteAsync(GetPointTypeRectangularParallepipedsFilter filter)
  {
    if (!await _pointTypeRepository.DoesExistAsync(filter.PointTypeId))
    {
      return new OperationResultResponse<List<PointTypeRectangularParallepipedInfo>>(
          body: null,
          errors: new List<string> { "Point type not found." }
      );
    }

    if (!await _accessValidator.IsAdminAsync() && filter.IncludeDeactivated)
    {
      return new OperationResultResponse<List<PointTypeRectangularParallepipedInfo>>(
          body: null,
          errors: new List<string> { "Only admins can include deactivated parallelepipeds." }
      );
    }

    var parallelepipeds = await _parallelepipedRepository.FindAllAsync(filter);
    return new OperationResultResponse<List<PointTypeRectangularParallepipedInfo>>(
        body: parallelepipeds.Select(_mapper.Map).ToList(),
        errors: new List<string>()
    );
  }
}