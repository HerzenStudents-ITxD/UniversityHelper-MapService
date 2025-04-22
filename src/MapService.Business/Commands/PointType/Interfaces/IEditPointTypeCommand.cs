using System;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Business.Commands.PointType.Interfaces;

[AutoInject]
public interface IEditPointTypeCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid typeId, EditPointTypeRequest request);
}