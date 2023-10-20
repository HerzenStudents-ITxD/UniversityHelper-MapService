//using System.Collections.Generic;
//using FluentValidation;
//using HerzenHelper.MapService.Validation.Helpers.Interfaces;
//using HerzenHelper.MapService.Validation.Interfaces;

//namespace HerzenHelper.MapService.Validation
//{
//    public class RightsIdsValidator : AbstractValidator<IEnumerable<int>>, IRightsIdsValidator
//    {
//        private readonly IMemoryCacheHelper _memoryCacheHelper;
//        private readonly ICheckRightsUniquenessHelper _checkRightsUniquenessHelper;

//        public RightsIdsValidator(
//          IMemoryCacheHelper memoryCacheHelper,
//          ICheckRightsUniquenessHelper checkRightsUniquenessHelper)
//        {
//            _memoryCacheHelper = memoryCacheHelper;
//            _checkRightsUniquenessHelper = checkRightsUniquenessHelper;

//            RuleFor(rightsIds => rightsIds)
//              .NotEmpty().WithMessage("Rights list can not be empty.")
//              .MustAsync(async (rightIds, _) => await _checkRightsUniquenessHelper.IsRightsSetUniqueAsync(rightIds))
//              .WithMessage("Set of rights must be unique.");

//            RuleForEach(rightsIds => rightsIds)
//              .MustAsync(async (id, _) => (await _memoryCacheHelper.GetRightIdsAsync()).Contains(id))
//              .WithMessage("Element: {CollectionIndex} of rights list is not correct.");
//        }
//    }
//}
