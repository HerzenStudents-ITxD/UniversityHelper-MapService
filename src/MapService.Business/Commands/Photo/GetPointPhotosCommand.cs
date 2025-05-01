using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Photo.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Mappers.Models.Interfaces;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Business.Commands.Photo;

public class GetPointPhotosCommand : IGetPointPhotosCommand
{
  private readonly IPointPhotoRepository _photoRepository;
  private readonly IPointRepository _pointRepository;
  private readonly IPointPhotoInfoMapper _mapper;
  private readonly IAccessValidator _accessValidator;

  public GetPointPhotosCommand(
      IPointPhotoRepository photoRepository,
      IPointRepository pointRepository,
      IPointPhotoInfoMapper mapper,
      IAccessValidator accessValidator)
  {
    _photoRepository = photoRepository;
    _pointRepository = pointRepository;
    _mapper = mapper;
    _accessValidator = accessValidator;
  }

  public async Task<OperationResultResponse<List<PointPhotoInfo>>> ExecuteAsync(GetPointPhotosFilter filter)
  {
    if (!await _pointRepository.DoesExistAsync(filter.PointId))
    {
      return new OperationResultResponse<List<PointPhotoInfo>>
      (
            body: null,
        errors: new List<string> { "Point not found." }
      );
    }

    if (!await _accessValidator.IsAdminAsync() && filter.IncludeDeactivated)
    {
      return new OperationResultResponse<List<PointPhotoInfo>>
      (
            body: null,
        errors: new List<string> { "Only admins can include deactivated photos." }
      );
    }

    var photos = await _photoRepository.FindAllAsync(filter);
    return new OperationResultResponse<List<PointPhotoInfo>>
    {
      Body = photos.Select(_mapper.Map).ToList()
    };
  }
}