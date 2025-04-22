using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Validators.Interfaces;

namespace UniversityHelper.MapService.Validators;

public class EditRelationRequestValidator : AbstractValidator<EditRelationRequest>, IEditRelationRequestValidator
{
  public EditRelationRequestValidator()
  {
    RuleFor(x => x.FirstPointId)
        .NotEmpty()
        .When(x => x.FirstPointId.HasValue)
        .WithMessage("FirstPointId cannot be empty if provided.");

    RuleFor(x => x.SecondPointId)
        .NotEmpty()
        .When(x => x.SecondPointId.HasValue)
        .WithMessage("SecondPointId cannot be empty if provided.");

    RuleFor(x => x)
        .Must(x => x.FirstPointId.HasValue || x.SecondPointId.HasValue)
        .WithMessage("At least one of FirstPointId or SecondPointId must be provided.");

    RuleFor(x => x.SecondPointId)
        .NotEqual(x => x.FirstPointId)
        .When(x => x.FirstPointId.HasValue && x.SecondPointId.HasValue)
        .WithMessage("FirstPointId and SecondPointId must be different.");
  }

  public async Task<ValidationResult> ValidateAsync(EditRelationRequest request)
  {
    return await base.ValidateAsync(request);
  }
}