using FluentValidation.Results;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Validators.Interfaces;

[AutoInject]
public interface IEditPointLabelRequestValidator
{
  Task<ValidationResult> ValidateAsync(EditPointLabelRequest request);
}