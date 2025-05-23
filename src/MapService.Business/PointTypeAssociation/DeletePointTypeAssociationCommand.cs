﻿using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.PointTypeAssociation.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;

namespace UniversityHelper.MapService.Business.Commands.PointTypeAssociation;

public class DeletePointTypeAssociationCommand : IDeletePointTypeAssociationCommand
{
  private readonly IPointTypeAssociationRepository _associationRepository;
  private readonly IAccessValidator _accessValidator;

  public DeletePointTypeAssociationCommand(
      IPointTypeAssociationRepository associationRepository,
      IAccessValidator accessValidator)
  {
    _associationRepository = associationRepository;
    _accessValidator = accessValidator;
  }

  public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid associationId)
  {
    if (!await _accessValidator.IsAdminAsync())
    {
      return new OperationResultResponse<bool>
      (
            body: false,
        errors: new List<string> { "Only admins can delete associations." }
      );
    }

    if (!await _associationRepository.DoesExistAsync(associationId))
    {
      return new OperationResultResponse<bool>
      (
            body: false,
        errors: new List<string> { "Association not found." }
      );
    }

    var result = await _associationRepository.EditStatusAsync(associationId, false);
    return new OperationResultResponse<bool>
    {
      Body = result
    };
  }
}