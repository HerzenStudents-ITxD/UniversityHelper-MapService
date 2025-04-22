using FluentValidation.Results;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Validators.Interfaces;

[AutoInject]
public interface ICreatePointLabelRequestValidator
{
  Task<ValidationResult> ValidateAsync(CreatePointLabelRequest request);
}