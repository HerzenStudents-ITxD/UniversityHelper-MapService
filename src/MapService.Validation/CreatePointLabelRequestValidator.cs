using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Validators.Interfaces;

namespace UniversityHelper.MapService.Validators;

public class CreatePointLabelRequestValidator : AbstractValidator<CreatePointLabelRequest>, ICreatePointLabelRequestValidator
{
  public CreatePointLabelRequestValidator()
  {
    RuleFor(x => x.Name)
        .NotNull()
        .Must(HaveRequiredLocales)
        .WithMessage("Name must contain 'ru', 'en', and 'cn' locales.");
  }

  public async Task<ValidationResult> ValidateAsync(CreatePointLabelRequest request)
  {
    return await base.ValidateAsync(request);
  }

  private bool HaveRequiredLocales(Dictionary<string, string> dict)
  {
    return dict != null && dict.ContainsKey("ru") && dict.ContainsKey("en") && dict.ContainsKey("cn");
  }
}