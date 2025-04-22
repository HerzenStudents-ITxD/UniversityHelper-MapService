using System;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Business.Commands.PointType.Interfaces;

[AutoInject]
public interface ICreatePointTypeCommand
{
  Task<OperationResultResponse<Guid?>> ExecuteAsync(CreatePointTypeRequest request);
}