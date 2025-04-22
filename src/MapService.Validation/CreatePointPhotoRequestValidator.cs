using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Validators.Interfaces;

namespace UniversityHelper.MapService.Validators;

public class CreatePointPhotoRequestValidator : AbstractValidator<CreatePointPhotoRequest>, ICreatePointPhotoRequestValidator
{
  public CreatePointPhotoRequestValidator()
  {
    RuleFor(x => x.PointId)
        .NotEmpty()
        .WithMessage("PointId is required.");

    RuleFor(x => x.Content)
        .NotEmpty()
        .WithMessage("Photo content is required.");

    RuleFor(x => x.OrdinalNumber)
        .GreaterThanOrEqualTo(0)
        .WithMessage("Ordinal number must be non-negative.");
  }

  public async Task<ValidationResult> ValidateAsync(CreatePointPhotoRequest request)
  {
    return await base.ValidateAsync(request);
  }
}