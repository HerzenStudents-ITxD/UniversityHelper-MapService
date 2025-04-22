using System;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;

namespace UniversityHelper.MapService.Business.Commands.Location.Interfaces;

[AutoInject]
public interface IDeletePointCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid pointId);
}