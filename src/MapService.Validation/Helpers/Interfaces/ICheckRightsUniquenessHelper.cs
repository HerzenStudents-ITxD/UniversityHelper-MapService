using System.Collections.Generic;
using System.Threading.Tasks;
using HerzenHelper.Kernel.Attributes;

namespace HerzenHelper.MapService.Validation.Helpers.Interfaces
{
    [AutoInject]
    public interface ICheckRightsUniquenessHelper
    {
        Task<bool> IsRightsSetUniqueAsync(IEnumerable<int> rightsIds);
    }
}
