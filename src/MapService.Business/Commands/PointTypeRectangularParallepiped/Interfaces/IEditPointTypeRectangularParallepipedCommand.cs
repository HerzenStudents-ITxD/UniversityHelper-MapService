using System;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Business.Commands.PointTypeRectangularParallepiped.Interfaces;

[AutoInject]
public interface IEditPointTypeRectangularParallepipedCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid parallelepipedId, EditPointTypeRectangularParallepipedRequest request);
}