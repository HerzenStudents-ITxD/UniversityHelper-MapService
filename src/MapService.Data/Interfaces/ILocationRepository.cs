using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HerzenHelper.Core.Attributes;
using HerzenHelper.MapService.Models.Db;
using HerzenHelper.MapService.Models.Dto.Requests.Filters;

namespace HerzenHelper.MapService.Data.Interfaces
{
    [AutoInject]
    public interface ILocationRepository
    {
        Task CreateAsync(DbLocation dbLocation);

        Task<DbLocation> GetAsync(GetLocationFilter filter);

        Task<List<DbLocation>> FindAllAsync(FindLocationsFilter filter);

        Task<bool> DoesExistAsync(Guid locationId);

        Task<bool> EditStatusAsync(Guid locationId, bool isActive);
    }
}
