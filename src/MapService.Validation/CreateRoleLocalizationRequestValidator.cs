﻿//using FluentValidation;
//using HerzenHelper.MapService.Data.Interfaces;
//using HerzenHelper.MapService.Models.Dto.Requests;
//using HerzenHelper.MapService.Validation.Interfaces;

//namespace HerzenHelper.MapService.Validation
//{
//    public class CreateRoleLocalizationRequestValidator : AbstractValidator<CreateRoleLocalizationRequest>, ICreateRoleLocalizationRequestValidator
//    {
//        public CreateRoleLocalizationRequestValidator(
//          IRoleRepository roleRepository,
//          IRoleLocalizationRepository localizationRepository)
//        {
//            RuleFor(x => x.Locale)
//              .Length(2);

//            RuleFor(x => x.Name)
//              .MaximumLength(100);

//            RuleFor(x => x)
//              .MustAsync(async (x, _) => !await localizationRepository.DoesNameExistAsync(x.Locale, x.Name))
//              .WithMessage("Role name should be unique.");

//            When(x => x.RoleId.HasValue, () =>
//            {
//                RuleFor(x => x)
//            .MustAsync(async (x, _) => await roleRepository.DoesExistAsync(x.RoleId.Value))
//            .WithMessage("Role must exist.")
//            .MustAsync(async (x, _) => !await localizationRepository.DoesLocaleExistAsync(x.RoleId.Value, x.Locale))
//            .WithMessage("Role must have only one localization per locale.");
//            });
//        }
//    }
//}
