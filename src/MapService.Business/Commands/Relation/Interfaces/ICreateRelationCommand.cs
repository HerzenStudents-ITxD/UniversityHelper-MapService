using System;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Business.Commands.Relation.Interfaces;

[AutoInject]
public interface ICreateRelationCommand
{
  Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateRelationRequest request);
}