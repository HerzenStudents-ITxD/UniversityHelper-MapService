using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Business.Commands.Location.Interfaces;

[AutoInject]
public interface IGetPointCommand
{
  Task<OperationResultResponse<PointInfo>> ExecuteAsync(GetPointFilter filter);
}