using System;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Business.Commands.Association.Interfaces;

[AutoInject]
public interface IEditPointAssociationCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid associationId, EditPointAssociationRequest request);
}