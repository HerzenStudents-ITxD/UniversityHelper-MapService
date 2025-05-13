using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Validators.Interfaces;

namespace UniversityHelper.MapService.Validators;

public class EditPointTypeRequestValidator : AbstractValidator<EditPointTypeRequest>, IEditPointTypeRequestValidator
{
  public EditPointTypeRequestValidator()
  {
    RuleFor(x => x.Name)
        .Must(HaveRequiredLocales)
        .When(x => x.Name != null)
        .WithMessage("Name must contain 'ru', 'en', and 'cn' locales if provided.");

    RuleFor(x => x.Icon)
        .NotEmpty()
        .When(x => x.Icon != null)
        .WithMessage("Icon cannot be empty if provided.");

    RuleFor(x => x)
        .Must(x => x.Name != null || x.Icon != null || x.Associations != null || x.IsActive.HasValue)
        .WithMessage("At least one field must be provided for update.");
  }

  public async Task<ValidationResult> ValidateAsync(EditPointTypeRequest request)
  {
    return await base.ValidateAsync(request);
  }

  private bool HaveRequiredLocales(Dictionary<string, string> dict)
  {
    return dict != null && dict.ContainsKey("ru") && dict.ContainsKey("en") && dict.ContainsKey("cn");
  }
}