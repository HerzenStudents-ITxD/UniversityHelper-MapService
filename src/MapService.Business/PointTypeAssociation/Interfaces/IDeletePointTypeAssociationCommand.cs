using System;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;

namespace UniversityHelper.MapService.Business.Commands.PointTypeAssociation.Interfaces;

[AutoInject]
public interface IDeletePointTypeAssociationCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid associationId);
}