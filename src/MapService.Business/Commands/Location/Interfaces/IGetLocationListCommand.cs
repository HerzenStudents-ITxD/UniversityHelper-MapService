using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.Responses;
using HerzenHelper.MapService.Models.Dto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HerzenHelper.MapService.Business.Commands.Right.Interfaces
{
    [AutoInject]
    public interface IGetLocationListCommand
    {
        Task<OperationResultResponse<List<LocationInfo>>> ExecuteAsync(string locale);
    }
}
