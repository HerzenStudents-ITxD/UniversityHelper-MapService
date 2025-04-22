using System;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Business.Commands.PointTypeRectangularParallepiped.Interfaces;

[AutoInject]
public interface ICreatePointTypeRectangularParallepipedCommand
{
  Task<OperationResultResponse<Guid?>> ExecuteAsync(CreatePointTypeRectangularParallepipedRequest request);
}