using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.PointTypeAssociation.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Mappers.Models.Interfaces;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Business.Commands.PointTypeAssociation;

public class GetPointTypeAssociationsCommand : IGetPointTypeAssociationsCommand
{
  private readonly IPointTypeAssociationRepository _associationRepository;
  private readonly IPointTypeRepository _pointTypeRepository;
  private readonly IPointTypeAssociationInfoMapper _mapper;
  private readonly IAccessValidator _accessValidator;

  public GetPointTypeAssociationsCommand(
      IPointTypeAssociationRepository associationRepository,
      IPointTypeRepository pointTypeRepository,
      IPointTypeAssociationInfoMapper mapper,
      IAccessValidator accessValidator)
  {
    _associationRepository = associationRepository;
    _pointTypeRepository = pointTypeRepository;
    _mapper = mapper;
    _accessValidator = accessValidator;
  }

  public async Task<OperationResultResponse<List<PointTypeAssociationInfo>>> ExecuteAsync(GetPointTypeAssociationsFilter filter)
  {
    if (!await _pointTypeRepository.DoesExistAsync(filter.PointTypeId))
    {
      return new OperationResultResponse<List<PointTypeAssociationInfo>>
      (
            body: null,
        errors: new List<string> { "Point type not found." }
      );
    }

    if (!await _accessValidator.IsAdminAsync() && filter.IncludeDeactivated)
    {
      return new OperationResultResponse<List<PointTypeAssociationInfo>>
      (
            body: null,
        errors: new List<string> { "Only admins can include deactivated associations." }
      );
    }

    var associations = await _associationRepository.FindAllAsync(filter);
    return new OperationResultResponse<List<PointTypeAssociationInfo>>
    {
      Body = associations.Select(_mapper.Map).ToList()
    };
  }
}