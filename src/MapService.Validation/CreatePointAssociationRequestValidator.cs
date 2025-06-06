﻿using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;
using UniversityHelper.MapService.Models.Dto.Requests;
using UniversityHelper.MapService.Validators.Interfaces;

namespace UniversityHelper.MapService.Validators;

public class CreatePointAssociationRequestValidator : AbstractValidator<CreatePointAssociationRequest>, ICreatePointAssociationRequestValidator
{
  public CreatePointAssociationRequestValidator()
  {
    RuleFor(x => x.Association)
        .NotEmpty()
        .WithMessage("Association is required.")
        .MaximumLength(100)
        .WithMessage("Association cannot exceed 100 characters.");
  }

  public async Task<ValidationResult> ValidateAsync(CreatePointAssociationRequest request)
  {
    return await base.ValidateAsync(request);
  }
}