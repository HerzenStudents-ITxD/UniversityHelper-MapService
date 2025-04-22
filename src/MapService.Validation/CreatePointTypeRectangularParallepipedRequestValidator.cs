using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Validators.Interfaces;

namespace UniversityHelper.MapService.Validators;

public class CreatePointTypeRectangularParallepipedRequestValidator : AbstractValidator<CreatePointTypeRectangularParallepipedRequest>, ICreatePointTypeRectangularParallepipedRequestValidator
{
  public CreatePointTypeRectangularParallepipedRequestValidator()
  {
    RuleFor(x => x.PointTypeId)
        .NotEmpty()
        .WithMessage("PointTypeId is required.");

    RuleFor(x => x.XMin)
        .LessThan(x => x.XMax)
        .WithMessage("XMin must be less than XMax.");

    RuleFor(x => x.YMin)
        .LessThan(x => x.YMax)
        .WithMessage("YMin must be less than YMax.");

    RuleFor(x => x.ZMin)
        .LessThan(x => x.ZMax)
        .WithMessage("ZMin must be less than ZMax.");
  }

  public async Task<ValidationResult> ValidateAsync(CreatePointTypeRectangularParallepipedRequest request)
  {
    return await base.ValidateAsync(request);
  }
}