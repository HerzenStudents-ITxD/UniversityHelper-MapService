using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.Responses;
using HerzenHelper.MapService.Models.Dto.Models;
using HerzenHelper.MapService.Models.Dto.Requests.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HerzenHelper.MapService.Business.Commands.Right.Interfaces
{
    [AutoInject]
    public interface IFindLocationsCommand
    {
        Task<OperationResultResponse<List<LocationInfo>>> ExecuteAsync(FindLocationsFilter filter);
    }
}
