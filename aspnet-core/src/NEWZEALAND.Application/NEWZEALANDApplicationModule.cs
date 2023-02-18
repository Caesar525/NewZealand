using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NEWZEALAND.Authorization;

namespace NEWZEALAND
{
    [DependsOn(
        typeof(NEWZEALANDCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class NEWZEALANDApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<NEWZEALANDAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(NEWZEALANDApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
