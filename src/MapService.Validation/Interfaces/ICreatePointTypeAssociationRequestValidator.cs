using FluentValidation.Results;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.MapService.Models.Dto.Requests;

namespace UniversityHelper.MapService.Validators.Interfaces;

[AutoInject]
public interface ICreatePointTypeAssociationRequestValidator
{
  Task<ValidationResult> ValidateAsync(CreatePointTypeAssociationRequest request);
}