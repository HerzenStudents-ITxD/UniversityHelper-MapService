﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Label.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Mappers.Models.Interfaces;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Business.Commands.Label;

public class GetPointLabelsCommand : IGetPointLabelsCommand
{
  private readonly IPointLabelRepository _repository;
  private readonly IPointLabelInfoMapper _mapper;
  private readonly IAccessValidator _accessValidator;

  public GetPointLabelsCommand(
      IPointLabelRepository repository,
      IPointLabelInfoMapper mapper,
      IAccessValidator accessValidator)
  {
    _repository = repository;
    _mapper = mapper;
    _accessValidator = accessValidator;
  }

  public async Task<OperationResultResponse<List<PointLabelInfo>>> ExecuteAsync(GetPointLabelsFilter filter)
  {
    if (!await _accessValidator.IsAdminAsync() && filter.IncludeDeactivated)
    {
      return new OperationResultResponse<List<PointLabelInfo>>
      (
            body: null,
        errors: new List<string> { "Only admins can include deactivated labels." }
      );
    }

    var labels = await _repository.FindAllAsync(filter);
    return new OperationResultResponse<List<PointLabelInfo>>
    {
      Body = labels.Select(_mapper.Map).ToList()
    };
  }
}