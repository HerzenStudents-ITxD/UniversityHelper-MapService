using System;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;

namespace UniversityHelper.MapService.Business.Commands.Photo.Interfaces;

[AutoInject]
public interface IDeletePointPhotoCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid photoId);
}