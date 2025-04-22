using System;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;

namespace UniversityHelper.MapService.Business.Commands.PointTypeRectangularParallepiped.Interfaces;

[AutoInject]
public interface IDeletePointTypeRectangularParallepipedCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid parallelepipedId);
}