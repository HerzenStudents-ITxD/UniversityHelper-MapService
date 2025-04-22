using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Validators.Interfaces;

namespace UniversityHelper.MapService.Validators;

public class EditPointPhotoRequestValidator : AbstractValidator<EditPointPhotoRequest>, IEditPointPhotoRequestValidator
{
  public EditPointPhotoRequestValidator()
  {
    RuleFor(x => x.Content)
        .NotEmpty()
        .When(x => x.Content != null)
        .WithMessage("Content cannot be empty if provided.");

    RuleFor(x => x.OrdinalNumber)
        .GreaterThanOrEqualTo(0)
        .When(x => x.OrdinalNumber.HasValue)
        .WithMessage("Ordinal number must be non-negative if provided.");

    RuleFor(x => x)
        .Must(x => x.Content != null || x.OrdinalNumber.HasValue || x.IsActive.HasValue)
        .WithMessage("At least one field must be provided for update.");
  }

  public async Task<ValidationResult> ValidateAsync(EditPointPhotoRequest request)
  {
    return await base.ValidateAsync(request);
  }
}