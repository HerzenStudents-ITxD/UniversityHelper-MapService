using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Validators.Interfaces;

namespace UniversityHelper.MapService.Validators;

public class EditPointTypeRectangularParallepipedRequestValidator : AbstractValidator<EditPointTypeRectangularParallepipedRequest>, IEditPointTypeRectangularParallepipedRequestValidator
{
  public EditPointTypeRectangularParallepipedRequestValidator()
  {
    RuleFor(x => x)
        .Must(x => x.XMin.HasValue || x.XMax.HasValue || x.YMin.HasValue || x.YMax.HasValue || x.ZMin.HasValue || x.ZMax.HasValue || x.IsActive.HasValue)
        .WithMessage("At least one field must be provided for update.");

    RuleFor(x => x.XMin)
        .LessThan(x => x.XMax ?? double.MaxValue)
        .When(x => x.XMin.HasValue && x.XMax.HasValue)
        .WithMessage("XMin must be less than XMax.");

    RuleFor(x => x.YMin)
        .LessThan(x => x.YMax ?? double.MaxValue)
        .When(x => x.YMin.HasValue && x.YMax.HasValue)
        .WithMessage("YMin must be less than YMax.");

    RuleFor(x => x.ZMin)
        .LessThan(x => x.ZMax ?? double.MaxValue)
        .When(x => x.ZMin.HasValue && x.ZMax.HasValue)
        .WithMessage("ZMin must be less than ZMax.");
  }

  public async Task<ValidationResult> ValidateAsync(EditPointTypeRectangularParallepipedRequest request)
  {
    return await base.ValidateAsync(request);
  }
}