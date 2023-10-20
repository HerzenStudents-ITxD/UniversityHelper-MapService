//using FluentValidation;
//using HerzenHelper.MapService.Data.Interfaces;
//using HerzenHelper.MapService.Models.Dto.Requests;
//using HerzenHelper.MapService.Validation.Interfaces;

//namespace HerzenHelper.MapService.Validation
//{
//    public class UpdateRoleRightsRequestValidator : AbstractValidator<UpdateRoleRightsRequest>, IUpdateRoleRightsRequestValidator
//    {
//        public UpdateRoleRightsRequestValidator(
//          IRoleRepository roleRepository,
//          IRightsIdsValidator rightsIdsValidator)
//        {
//            RuleFor(request => request.RoleId)
//              .MustAsync(async (roleId, _) => await roleRepository.DoesExistAsync(roleId))
//              .WithMessage("Role doesn't exist.");

//            RuleFor(request => request.Rights)
//              .SetValidator(rightsIdsValidator);
//        }
//    }
//}
