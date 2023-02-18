using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace NEWZEALAND.Controllers
{
    public abstract class NEWZEALANDControllerBase: AbpController
    {
        protected NEWZEALANDControllerBase()
        {
            LocalizationSourceName = NEWZEALANDConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
