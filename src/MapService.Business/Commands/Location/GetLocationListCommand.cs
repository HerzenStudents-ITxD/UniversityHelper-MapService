﻿//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Threading.Tasks;
//using HerzenHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
//using HerzenHelper.Core.Helpers.Interfaces;
//using HerzenHelper.Core.Responses;
//using HerzenHelper.MapService.Business.Commands.Right.Interfaces;
//using HerzenHelper.MapService.Data.Interfaces;
//using HerzenHelper.MapService.Mappers.Models.Interfaces;
//using HerzenHelper.MapService.Models.Dto;
//using HerzenHelper.MapService.Models.Dto.Models;

//namespace HerzenHelper.MapService.Business.Commands.Right
//{
//    public class GetLocationListCommand : IGetLocationListCommand
//    {
//        private readonly ILocationRepository _repository;
//        private readonly ILocationInfoMapper _mapper;
//        private readonly IAccessValidator _accessValidator;
//        private readonly IResponseCreator _responseCreator;

//        public GetLocationListCommand(
//        ILocationRepository repository,
//        ILocationInfoMapper mapper,
//        IAccessValidator accessValidator,
//        IResponseCreator responseCreator)
//        {
//            _repository = repository;
//            _mapper = mapper;
//            _accessValidator = accessValidator;
//            _responseCreator = responseCreator;
//        }

//        public async Task<OperationResultResponse<List<LocationInfo>>> ExecuteAsync(string locale)
//        {
//            return await _accessValidator.IsAdminAsync()
//            ? new OperationResultResponse<List<LocationInfo>>(
//                body: (await _repository.GetLocationListAsync(locale))?.Select(_mapper.Map).ToList())
//            : _responseCreator.CreateFailureResponse<List<LocationInfo>>(HttpStatusCode.Forbidden);
//        }
//    }
//}
