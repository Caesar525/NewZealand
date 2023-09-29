﻿using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace NEWZEALAND.Authorization
{
    public class NEWZEALANDAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            //新增
            context.CreatePermission(PermissionNames.Pages_Consume, L("Consume"));
            context.CreatePermission(PermissionNames.Pages_ConsumeList, L("ConsumeList"));
            context.CreatePermission(PermissionNames.Pages_Budget, L("Budget"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, NEWZEALANDConsts.LocalizationSourceName);
        }
    }
}
