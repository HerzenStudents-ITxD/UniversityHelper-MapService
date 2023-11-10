using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Helpers.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Right.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Mappers.Models.Interfaces;
using UniversityHelper.MapService.Models.Dto;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Business.Commands.Right
{
    public class FindLocationsCommand : IFindLocationsCommand
    {
        private readonly ILocationRepository _repository;
        private readonly ILocationInfoMapper _mapper;
        //private readonly IAccessValidator _accessValidator;
        //private readonly IResponseCreator _responseCreator;

        public FindLocationsCommand(
        ILocationRepository repository,
        ILocationInfoMapper mapper//,
        //IAccessValidator accessValidator,
        //IResponseCreator responseCreator
            )
        {
            _repository = repository;
            _mapper = mapper;
            //_accessValidator = accessValidator;
            //_responseCreator = responseCreator;
        }

        public async Task<OperationResultResponse<List<LocationInfo>>> ExecuteAsync(FindLocationsFilter filter)
        {
            return
                //await _accessValidator.IsAdminAsync() ? 
                new OperationResultResponse<List<LocationInfo>>(
                body: (await _repository.FindAllAsync(filter)).Select(_mapper.Map).ToList());
            //: _responseCreator.CreateFailureResponse<List<LocationInfo>>(HttpStatusCode.Forbidden);
        }
    }
}
