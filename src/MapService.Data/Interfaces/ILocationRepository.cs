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

        Task<(DbLocatione role, List<DbUserRole> users, List<DbRightLocalization> rights)> GetAsync(GetRoleFilter filter);

        Task<DbRole> GetAsync(Guid roleId);

        Task<List<DbRole>> GetAsync(List<Guid> rolesIds);

        Task<List<DbRole>> GetAllWithRightsAsync();

        Task<(List<(DbRole role, List<DbRightLocalization> rights)>, int totalCount)> FindAllAsync(FindRolesFilter filter);

        Task<(List<(DbRole role, List<DbRightLocalization> rights)>, int totalCount)> FindActiveAsync(FindRolesFilter filter);

        Task<bool> DoesExistAsync(Guid roleId);

        Task<bool> EditStatusAsync(Guid roleId, bool isActive);

        Task<bool> EditRoleRightsAsync(Guid roleId, List<DbRoleRight> newRights);
    }
}
