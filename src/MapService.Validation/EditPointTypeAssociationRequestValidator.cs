using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Validators.Interfaces;

namespace UniversityHelper.MapService.Validators;

public class EditPointTypeAssociationRequestValidator : AbstractValidator<EditPointTypeAssociationRequest>, IEditPointTypeAssociationRequestValidator
{
  public EditPointTypeAssociationRequestValidator()
  {
    RuleFor(x => x.Association)
        .NotEmpty()
        .When(x => x.Association != null)
        .WithMessage("Association cannot be empty if provided.")
        .MaximumLength(100)
        .When(x => x.Association != null)
        .WithMessage("Association cannot exceed 100 characters.");

    RuleFor(x => x)
        .Must(x => x.Association != null || x.IsActive.HasValue)
        .WithMessage("At least one field must be provided for update.");
  }

  public async Task<ValidationResult> ValidateAsync(EditPointTypeAssociationRequest request)
  {
    return await base.ValidateAsync(request);
  }
}