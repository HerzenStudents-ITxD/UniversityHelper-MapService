using System;
using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.PointTypeRectangularParallepiped.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Models.Dto.Requests;

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
      {
        StatusCode = HttpStatusCode.BadRequest,
        Message = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage))
      };
    }

    if (!await _accessValidator.IsAdminAsync() && !await _accessValidator.IsModeratorAsync())
    {
      return new OperationResultResponse<bool>
      {
        StatusCode = HttpStatusCode.Forbidden,
        Message = "Only admins or moderators can edit parallelepipeds."
      };
    }

    var parallelepiped = await _parallelepipedRepository.GetAsync(parallelepipedId);
    if (parallelepiped == null)
    {
      return new OperationResultResponse<bool>
      {
        StatusCode = HttpStatusCode.NotFound,
        Message = "Parallelepiped not found."
      };
    }

    if (request.XMin.HasValue)
      parallelepiped.XMin = request.XMin.Value;
    if (request.XMax.HasValue)
      parallelepiped.XMax = request.XMax.Value;
    if (request.YMin.HasValue)
      parallelepiped.YMin = request.YMin.Value;
    if (request.YMax.HasValue)
      parallelepiped.YMax = request.YMax.Value;
    if (request.ZMin.HasValue)
      parallelepiped.ZMin = request.ZMin.Value;
    if (request.ZMax.HasValue)
      parallelepiped.ZMax = request.ZMax.Value;
    if (request.IsActive.HasValue)
      parallelepiped.IsActive = request.IsActive.Value;

    await _parallelepipedRepository.UpdateAsync(parallelepiped);
    return new OperationResultResponse<bool>
    {
      Body = true
    };
  }
}