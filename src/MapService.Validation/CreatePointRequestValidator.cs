using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Validators.Interfaces;

namespace UniversityHelper.MapService.Validators;

public class CreatePointRequestValidator : AbstractValidator<CreatePointRequest>, ICreatePointRequestValidator
{
  public CreatePointRequestValidator()
  {
    RuleFor(x => x.Name)
        .NotNull()
        .Must(HaveRequiredLocales)
        .WithMessage("Name must contain 'ru', 'en', and 'cn' locales.");

    RuleFor(x => x.Description)
        .Must(HaveRequiredLocales)
        .When(x => x.Description != null)
        .WithMessage("Description must contain 'ru', 'en', and 'cn' locales if provided.");

    RuleFor(x => x.Fact)
        .Must(HaveRequiredLocales)
        .When(x => x.Fact != null)
        .WithMessage("Fact must contain 'ru', 'en', and 'cn' locales if provided.");

    RuleFor(x => x.X).NotNull().WithMessage("X coordinate is required.");
    RuleFor(x => x.Y).NotNull().WithMessage("Y coordinate is required.");
    RuleFor(x => x.Z).NotNull().WithMessage("Z coordinate is required.");
    RuleFor(x => x.Icon).NotEmpty().WithMessage("Icon is required.");

    RuleForEach(x => x.Photos)
        .SetValidator(new CreatePointPhotoRequestValidator());
  }

  public async Task<ValidationResult> ValidateAsync(CreatePointRequest request)
  {
    return await ValidateAsync(request);
  }

  private bool HaveRequiredLocales(Dictionary<string, string> dict)
  {
    return dict != null && dict.ContainsKey("ru") && dict.ContainsKey("en") && dict.ContainsKey("cn");
  }
}