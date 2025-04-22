using System;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;

namespace UniversityHelper.MapService.Business.Commands.Route.Interfaces;

[AutoInject]
public interface IDeleteRelationCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid relationId);
}