using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Validators.Interfaces;

namespace UniversityHelper.MapService.Validators;

public class CreatePointTypeRequestValidator : AbstractValidator<CreatePointTypeRequest>, ICreatePointTypeRequestValidator
{
  public CreatePointTypeRequestValidator()
  {
    RuleFor(x => x.Name)
        .NotNull()
        .Must(HaveRequiredLocales)
        .WithMessage("Name must contain 'ru', 'en', and 'zh' locales.");

    RuleFor(x => x.Icon)
        .NotEmpty()
        .WithMessage("Icon is required.");
  }

  public async Task<ValidationResult> ValidateAsync(CreatePointTypeRequest request)
  {
    return await base.ValidateAsync(request);
  }

  private bool HaveRequiredLocales(Dictionary<string, string> dict)
  {
    return dict != null && dict.ContainsKey("ru") && dict.ContainsKey("en") && dict.ContainsKey("zh");
  }
}