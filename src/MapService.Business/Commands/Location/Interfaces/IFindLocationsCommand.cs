using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversityHelper.MapService.Business.Commands.Right.Interfaces
{
    [AutoInject]
    public interface IFindLocationsCommand
    {
        Task<OperationResultResponse<List<LocationInfo>>> ExecuteAsync(FindLocationsFilter filter);
    }
}
