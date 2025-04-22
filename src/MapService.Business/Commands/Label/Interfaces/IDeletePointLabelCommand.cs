using System;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;

namespace UniversityHelper.MapService.Business.Commands.Label.Interfaces;

[AutoInject]
public interface IDeletePointLabelCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid labelId);
}