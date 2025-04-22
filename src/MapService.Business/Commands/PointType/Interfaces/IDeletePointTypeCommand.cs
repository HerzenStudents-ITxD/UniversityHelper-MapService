using System;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;

namespace UniversityHelper.MapService.Business.Commands.PointType.Interfaces;

[AutoInject]
public interface IDeletePointTypeCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid typeId);
}