using System;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Business.Commands.PointTypeAssociation.Interfaces;

[AutoInject]
public interface ICreatePointTypeAssociationCommand
{
  Task<OperationResultResponse<Guid?>> ExecuteAsync(CreatePointTypeAssociationRequest request);
}