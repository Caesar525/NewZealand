using Abp.Auditing;
using Abp.Localization;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Security;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using NEWZEALAND.Authorization.Roles;
using NEWZEALAND.Authorization.Users;
using NEWZEALAND.Configuration;
using NEWZEALAND.Localization;
using NEWZEALAND.MultiTenancy;
using NEWZEALAND.Timing;
using Castle.MicroKernel.Registration;
using NEWZEALAND.Audit;

namespace NEWZEALAND
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class NEWZEALANDCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            NEWZEALANDLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = NEWZEALANDConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();

            //Configuration.Localization.Languages.Add(new LanguageInfo("fa", "فارسی", "famfamfam-flags ir"));

            //Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = NEWZEALANDConsts.DefaultPassPhrase;
            //SimpleStringCipher.DefaultPassPhrase = NEWZEALANDConsts.DefaultPassPhrase;

            Configuration.ReplaceService(typeof(IAuditingStore), () =>
            {
                Configuration.IocManager.IocContainer.Register(
                    Component.For<IAuditingStore>()
                        .ImplementedBy<DzhAuditingLogStore>()
                        .LifestyleTransient()
                );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NEWZEALANDCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
