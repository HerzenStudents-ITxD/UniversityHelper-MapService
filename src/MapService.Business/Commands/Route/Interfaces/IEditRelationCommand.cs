using System;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Business.Commands.Route.Interfaces;

[AutoInject]
public interface IEditRelationCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid relationId, EditRelationRequest request);
}