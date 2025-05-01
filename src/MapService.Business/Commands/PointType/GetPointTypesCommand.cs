using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.PointType.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Mappers.Models.Interfaces;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Business.Commands.PointType;

public class GetPointTypesCommand : IGetPointTypesCommand
{
  private readonly IPointTypeRepository _repository;
  private readonly IPointTypeInfoMapper _mapper;
  private readonly IAccessValidator _accessValidator;

  public GetPointTypesCommand(
      IPointTypeRepository repository,
      IPointTypeInfoMapper mapper,
      IAccessValidator accessValidator)
  {
    _repository = repository;
    _mapper = mapper;
    _accessValidator = accessValidator;
  }

  public async Task<OperationResultResponse<List<PointTypeInfo>>> ExecuteAsync(GetPointTypesFilter filter)
  {
    if (!await _accessValidator.IsAdminAsync() && filter.IncludeDeactivated)
    {
      return new OperationResultResponse<List<PointTypeInfo>>
      (
            body: null,
        errors: new List<string> { "Only admins can include deactivated types." }
      );
    }

    var types = await _repository.FindAllAsync(filter);
    return new OperationResultResponse<List<PointTypeInfo>>
    {
      Body = types.Select(_mapper.Map).ToList()
    };
  }
}