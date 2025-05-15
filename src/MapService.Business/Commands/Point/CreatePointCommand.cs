using Microsoft.AspNetCore.Http;
using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Extensions;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Point.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Business.Commands.Point;

public class CreatePointCommand : ICreatePointCommand
{
  private readonly IPointRepository _repository;
  private readonly IAccessValidator _accessValidator;
  private readonly IHttpContextAccessor _httpContextAccessor;

  public CreatePointCommand(
      IPointRepository repository,
      IAccessValidator accessValidator,
      IHttpContextAccessor httpContextAccessor)
  {
    _repository = repository;
    _accessValidator = accessValidator;
    _httpContextAccessor = httpContextAccessor;
  }

  public async Task<OperationResultResponse<Guid?>> ExecuteAsync(CreatePointRequest request)
  {
    if (!await _accessValidator.IsAdminAsync())
    {
      return new OperationResultResponse<Guid?>
      (
            body: null,
        errors: new List<string> { "Only admins can create points." }
      );
    }

    request.Icon = string.IsNullOrWhiteSpace(request.Icon) ? null : request.Icon;

    if (!string.IsNullOrEmpty(request.Icon)
    && !IsValidBase64(request.Icon))
    {
      return new OperationResultResponse<Guid?>(
          body: null,
          errors: new List<string> { "Invalid Base64 format for Icon." }
      );
    }


    var userId = _httpContextAccessor.HttpContext.GetUserId();
    var point = new DbPoint
    {
      Id = Guid.NewGuid(),
      CreatedBy = userId,
      CreatedAtUtc = DateTime.UtcNow,
      IsActive = true,
      Name = JsonSerializer.Serialize(request.Name),
      Description = request.Description != null ? JsonSerializer.Serialize(request.Description) : null,
      Fact = request.Fact != null ? JsonSerializer.Serialize(request.Fact) : null,
      X = request.X,
      Y = request.Y,
      Z = request.Z,
      Icon = request.Icon,
      Labels = request.LabelIds?.Select(id => new DbPointLabel
      {
        Id = Guid.NewGuid(),
        LabelId = id,
        CreatedBy = userId,
        CreatedAtUtc = DateTime.UtcNow,
        IsActive = true
      }).ToList() ?? new List<DbPointLabel>(),
      Photos = request.Photos?.Select(p => new DbPointPhoto
      {
        Id = Guid.NewGuid(),
        Content = p.Content,
        OrdinalNumber = p.OrdinalNumber,
        CreatedBy = userId,
        CreatedAtUtc = DateTime.UtcNow,
        IsActive = true
      }).ToList() ?? new List<DbPointPhoto>(),
      PointTypes = request.TypeIds?.Select(id => new DbPointTypePoint
      {
        Id = Guid.NewGuid(),
        PointTypeId = id
      }).ToList() ?? new List<DbPointTypePoint>(),
      Associations = request.Associations?.Select(a => new DbPointAssociation
      {
        Id = Guid.NewGuid(),
        Association = a
      }).ToList() ?? new List<DbPointAssociation>()
    };

    await _repository.CreateAsync(point);
    return new OperationResultResponse<Guid?>
    {
      Body = point.Id
    };
  }
  private bool IsValidBase64(string base64)
  {
    if (string.IsNullOrEmpty(base64))
    {
      return false;
    }
    try
    {
      Convert.FromBase64String(base64);
      return true;
    }
    catch
    {
      return false;
    }
  }
}