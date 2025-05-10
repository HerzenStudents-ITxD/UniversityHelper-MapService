using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Validators.Interfaces;

namespace UniversityHelper.MapService.Validators;

public class EditPointLabelRequestValidator : AbstractValidator<EditPointLabelRequest>, IEditPointLabelRequestValidator
{
  public EditPointLabelRequestValidator()
  {
    RuleFor(x => x.Name)
        .Must(HaveRequiredLocales)
        .When(x => x.Name != null)
        .WithMessage("Name must contain 'ru', 'en', and 'cn' locales if provided.");
  }

  public async Task<ValidationResult> ValidateAsync(EditPointLabelRequest request)
  {
    return await base.ValidateAsync(request);
  }

  private bool HaveRequiredLocales(Dictionary<string, string> dict)
  {
    return dict != null && dict.ContainsKey("ru") && dict.ContainsKey("en") && dict.ContainsKey("cn");
  }
}