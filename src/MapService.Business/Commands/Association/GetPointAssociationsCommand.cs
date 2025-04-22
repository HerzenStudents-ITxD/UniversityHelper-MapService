using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Association.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Mappers.Models.Interfaces;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Business.Commands.Association;

public class GetPointAssociationsCommand : IGetPointAssociationsCommand
{
  private readonly IPointAssociationRepository _repository;
  private readonly IPointAssociationInfoMapper _mapper;
  private readonly IAccessValidator _accessValidator;

  public GetPointAssociationsCommand(
      IPointAssociationRepository repository,
      IPointAssociationInfoMapper mapper,
      IAccessValidator accessValidator)
  {
    _repository = repository;
    _mapper = mapper;
    _accessValidator = accessValidator;
  }

  public async Task<OperationResultResponse<List<PointAssociationInfo>>> ExecuteAsync(GetPointAssociationsFilter filter)
  {
    if (!await _accessValidator.IsAdminAsync() && filter.IncludeDeactivated)
    {
      return new OperationResultResponse<List<PointAssociationInfo>>
      {
        StatusCode = HttpStatusCode.Forbidden,
        Message = "Only admins can include deactivated associations."
      };
    }

    var associations = await _repository.FindAllAsync(filter);
    return new OperationResultResponse<List<PointAssociationInfo>>
    {
      Body = associations.Select(_mapper.Map).ToList()
    };
  }
}