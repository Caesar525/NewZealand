using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NEWZEALAND.Configuration;
using NEWZEALAND.EntityFrameworkCore;
using NEWZEALAND.Migrator.DependencyInjection;

namespace NEWZEALAND.Migrator
{
    [DependsOn(typeof(NEWZEALANDEntityFrameworkModule))]
    public class NEWZEALANDMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public NEWZEALANDMigratorModule(NEWZEALANDEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(NEWZEALANDMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                NEWZEALANDConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NEWZEALANDMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
