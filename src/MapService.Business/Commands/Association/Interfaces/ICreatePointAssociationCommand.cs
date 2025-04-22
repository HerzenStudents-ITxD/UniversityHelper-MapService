using System;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Business.Commands.Association.Interfaces;

[AutoInject]
public interface ICreatePointAssociationCommand
{
  Task<OperationResultResponse<Guid?>> ExecuteAsync(CreatePointAssociationRequest request);
}