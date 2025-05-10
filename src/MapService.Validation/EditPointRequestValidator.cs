using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Validators.Interfaces;

namespace UniversityHelper.MapService.Validators;

public class EditPointRequestValidator : AbstractValidator<EditPointRequest>, IEditPointRequestValidator
{
  public EditPointRequestValidator()
  {
    RuleFor(x => x.Name)
        .Must(HaveRequiredLocales)
        .When(x => x.Name != null)
        .WithMessage("Name must contain 'ru', 'en', and 'cn' locales if provided.");

    RuleFor(x => x.Description)
        .Must(HaveRequiredLocales)
        .When(x => x.Description != null)
        .WithMessage("Description must contain 'ru', 'en', and 'cn' locales if provided.");

    RuleFor(x => x.Fact)
        .Must(HaveRequiredLocales)
        .When(x => x.Fact != null)
        .WithMessage("Fact must contain 'ru', 'en', and 'cn' locales if provided.");

    RuleForEach(x => x.Photos)
        .SetValidator(new CreatePointPhotoRequestValidator())
        .When(x => x.Photos != null);
  }

  public async Task<ValidationResult> ValidateAsync(EditPointRequest request)
  {
    return await base.ValidateAsync(request);
  }

  private bool HaveRequiredLocales(Dictionary<string, string> dict)
      => dict != null && dict.ContainsKey("ru") && dict.ContainsKey("en") && dict.ContainsKey("cn");
}