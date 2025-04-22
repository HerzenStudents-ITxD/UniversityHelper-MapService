using System;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Business.Commands.Location.Interfaces;

[AutoInject]
public interface IEditPointCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid pointId, EditPointRequest request);
}