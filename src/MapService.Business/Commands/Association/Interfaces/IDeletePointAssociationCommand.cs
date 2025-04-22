using System;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;

namespace UniversityHelper.MapService.Business.Commands.Association.Interfaces;

[AutoInject]
public interface IDeletePointAssociationCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid associationId);
}