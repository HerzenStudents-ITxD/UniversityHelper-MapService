﻿using System;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Business.Commands.Photo.Interfaces;

[AutoInject]
public interface ICreatePointPhotoCommand
{
  Task<OperationResultResponse<Guid?>> ExecuteAsync(CreatePointPhotoRequest request);
}