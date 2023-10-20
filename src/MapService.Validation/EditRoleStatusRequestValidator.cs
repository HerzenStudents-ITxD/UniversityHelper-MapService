//using System;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using FluentValidation;
//using FluentValidation.Validators;
//using HerzenHelper.MapService.Data.Interfaces;
//using HerzenHelper.MapService.Models.Db;
//using HerzenHelper.MapService.Validation.Helpers.Interfaces;
//using HerzenHelper.MapService.Validation.Interfaces;

//namespace HerzenHelper.MapService.Validation
//{
//    public class EditRoleStatusRequestValidator : AbstractValidator<(Guid roleId, bool isActive)>, IEditRoleStatusRequestValidator
//    {
//        private readonly IRoleRepository _roleRepository;
//        private readonly ICheckRightsUniquenessHelper _checkRightsUniquenessHelper;

//        private async Task CheckEnablePossibilityAsync(
//          (Guid roleId, bool isActive) tuple,
//          ValidationContext<(Guid, bool)> context,
//          CancellationToken _)
//        {
//            DbRole role = await _roleRepository.GetAsync(tuple.roleId);

//            if (role is null)
//            {
//                context.AddFailure("Can't find role with this ID.");
//                return;
//            }

//            if (role.IsActive == tuple.isActive)
//            {
//                context.AddFailure("Role already has this status.");
//                return;
//            }

//            if (tuple.isActive && !await _checkRightsUniquenessHelper.IsRightsSetUniqueAsync(role.RolesRights.Select(x => x.RightId)))
//            {
//                context.AddFailure("Role's set of rights are not unique.");
//                return;
//            }
//        }

//        public EditRoleStatusRequestValidator(
//          IRoleRepository roleRepository,
//          ICheckRightsUniquenessHelper checkRightsUniquenessHelper)
//        {
//            _roleRepository = roleRepository;
//            _checkRightsUniquenessHelper = checkRightsUniquenessHelper;

//            RuleFor(x => x)
//              .CustomAsync(CheckEnablePossibilityAsync);
//        }
//    }
//}
