using FluentValidation.Results;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Validators.Interfaces;

[AutoInject]
public interface ICreatePointTypeRectangularParallepipedRequestValidator
{
  Task<ValidationResult> ValidateAsync(CreatePointTypeRectangularParallepipedRequest request);
}