using System;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Business.Commands.Label.Interfaces;

[AutoInject]
public interface ICreatePointLabelCommand
{
  Task<OperationResultResponse<Guid?>> ExecuteAsync(CreatePointLabelRequest request);
}