using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Validators.Interfaces;

namespace UniversityHelper.MapService.Validators;

public class CreateRelationRequestValidator : AbstractValidator<CreateRelationRequest>, ICreateRelationRequestValidator
{
  public CreateRelationRequestValidator()
  {
    RuleFor(x => x.FirstPointId)
        .NotEmpty()
        .WithMessage("FirstPointId is required.");

    RuleFor(x => x.SecondPointId)
        .NotEmpty()
        .WithMessage("SecondPointId is required.");

    RuleFor(x => x.SecondPointId)
        .NotEqual(x => x.FirstPointId)
        .WithMessage("FirstPointId and SecondPointId must be different.");
  }

  public async Task<ValidationResult> ValidateAsync(CreateRelationRequest request)
  {
    return await base.ValidateAsync(request);
  }
}