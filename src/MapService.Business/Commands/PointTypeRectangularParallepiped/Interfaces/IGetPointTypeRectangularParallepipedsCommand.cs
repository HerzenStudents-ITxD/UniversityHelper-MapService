﻿using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Business.Commands.PointTypeRectangularParallepiped.Interfaces;

[AutoInject]
public interface IGetPointTypeRectangularParallepipedsCommand
{
  Task<OperationResultResponse<List<PointTypeRectangularParallepipedInfo>>> ExecuteAsync(GetPointTypeRectangularParallepipedsFilter filter);
}