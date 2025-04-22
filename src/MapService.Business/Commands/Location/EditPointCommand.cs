using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Location.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Business.Commands.Location;

public class EditPointCommand : IEditPointCommand
{
  private readonly IPointRepository _repository;
  private readonly IAccessValidator _accessValidator;
  private readonly IHttpContextAccessor _httpContextAccessor;

  public EditPointCommand(
      IPointRepository repository,
      IAccessValidator accessValidator,
      IHttpContextAccessor httpContextAccessor)
  {
    _repository = repository;
    _accessValidator = accessValidator;
    _httpContextAccessor = httpContextAccessor;
  }

  public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid pointId, EditPointRequest request)
  {
    if (!await _accessValidator.IsAdminAsync() && !await _accessValidator.IsModeratorAsync())
    {
      return new OperationResultResponse<bool>
      {
        StatusCode = HttpStatusCode.Forbidden,
        Message = "Only admins or moderators can edit points."
      };
    }

    var point = await _repository.GetAsync(new GetPointFilter { PointId = pointId });
    if (point == null)
    {
      return new OperationResultResponse<bool>
      {
        StatusCode = HttpStatusCode.NotFound,
        Message = "Point not found."
      };
    }

    if (request.Name != null)
      point.Name = JsonSerializer.Serialize(request.Name);
    if (request.Description != null)
      point.Description = JsonSerializer.Serialize(request.Description);
    if (request.Fact != null)
      point.Fact = JsonSerializer.Serialize(request.Fact);
    if (request.X.HasValue)
      point.X = request.X.Value;
    if (request.Y.HasValue)
      point.Y = request.Y.Value;
    if (request.Z.HasValue)
      point.Z = request.Z.Value;
    if (request.Icon != null)
      point.Icon = request.Icon;
    if (request.IsActive.HasValue)
      point.IsActive = request.IsActive.Value;

    if (request.LabelIds != null)
    {
      point.Labels = request.LabelIds.Select(id => new DbPointLabel
      {
        Id = Guid.NewGuid(),
        LabelId = id,
        CreatedBy = _httpContextAccessor.HttpContext.GetUserId(),
        CreatedAtUtc = DateTime.UtcNow,
        IsActive = true
      }).ToList();
    }

    if (request.Photos != null)
    {
      point.Photos = request.Photos.Select(p => new DbPointPhoto
      {
        Id = Guid.NewGuid(),
        Content = p.Content,
        OrdinalNumber = p.OrdinalNumber,
        CreatedBy = _httpContextAccessor.HttpContext.GetUserId(),
        CreatedAtUtc = DateTime.UtcNow,
        IsActive = true
      }).ToList();
    }

    if (request.TypeIds != null)
    {
      point.PointTypes = request.TypeIds.Select(id => new DbPointTypePoint
      {
        Id = Guid.NewGuid(),
        PointTypeId = id
      }).ToList();
    }

    if (request.Associations != null)
    {
      point.Associations = request.Associations.Select(a => new DbPointAssociation
      {
        Id = Guid.NewGuid(),
        Association = a
      }).ToList();
    }

    await _repository.UpdateAsync(point);
    return new OperationResultResponse<bool>
    {
      Body = true
    };
  }
}