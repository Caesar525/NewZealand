using Abp.Authorization;
using NEWZEALAND.Authorization.Roles;
using NEWZEALAND.Authorization.Users;

namespace NEWZEALAND.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
