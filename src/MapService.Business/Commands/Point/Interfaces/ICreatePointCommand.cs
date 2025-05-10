using System;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Business.Commands.Point.Interfaces;

[AutoInject]
public interface ICreatePointCommand
{
  Task<OperationResultResponse<Guid?>> ExecuteAsync(CreatePointRequest request);
}