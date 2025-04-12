using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversityHelper.MapService.Business.Commands.Right.Interfaces;

[AutoInject]
public interface IFindPointsCommand
{
  Task<OperationResultResponse<List<PointInfo>>> ExecuteAsync(FindPointsFilter filter);
}
