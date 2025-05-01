using System;
using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.PointTypeRectangularParallepiped.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Validators.Interfaces;

namespace UniversityHelper.MapService.Business.Commands.PointTypeRectangularParallepiped;

public class EditPointTypeRectangularParallepipedCommand : IEditPointTypeRectangularParallepipedCommand
{
  private readonly IPointTypeRectangularParallepipedRepository _parallelepipedRepository;
  private readonly IAccessValidator _accessValidator;
  private readonly IEditPointTypeRectangularParallepipedRequestValidator _validator;

  public EditPointTypeRectangularParallepipedCommand(
      IPointTypeRectangularParallepipedRepository parallelepipedRepository,
      IAccessValidator accessValidator,
      IEditPointTypeRectangularParallepipedRequestValidator validator)
  {
    _parallelepipedRepository = parallelepipedRepository;
    _accessValidator = accessValidator;
    _validator = validator;
  }

  public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid parallelepipedId, EditPointTypeRectangularParallepipedRequest request)
  {
    var validationResult = await _validator.ValidateAsync(request);
    if (!validationResult.IsValid)
    {
      return new OperationResultResponse<bool>
      (
            body: false,
            errors: validationResult.Errors.Select(e => e.ErrorMessage).ToList()
      );
    }

    if (!await _accessValidator.IsAdminAsync())
    {
      return new OperationResultResponse<bool>
      (
            body: false,
            errors: new List<string> { "Only admins can edit parallelepipeds." }
      );
    }

    var parallelepiped = await _parallelepipedRepository.GetAsync(parallelepipedId);
    if (parallelepiped == null)
    {
      return new OperationResultResponse<bool>
      (
        body: false,
        errors: new List<string> { "Parallelepiped not found." }
      );
    }

    if (request.XMin.HasValue)
      parallelepiped.XMin = (float)request.XMin.Value;
    if (request.XMax.HasValue)
      parallelepiped.XMax = (float)request.XMax.Value;
    if (request.YMin.HasValue)
      parallelepiped.YMin = (float)request.YMin.Value;
    if (request.YMax.HasValue)
      parallelepiped.YMax = (float)request.YMax.Value;
    if (request.ZMin.HasValue)
      parallelepiped.ZMin = (float)request.ZMin.Value;
    if (request.ZMax.HasValue)
      parallelepiped.ZMax = (float)request.ZMax.Value;
    if (request.IsActive.HasValue)
      parallelepiped.IsActive = request.IsActive.Value;

    await _parallelepipedRepository.UpdateAsync(parallelepiped);
    return new OperationResultResponse<bool>
    {
      Body = true
    };
  }
}