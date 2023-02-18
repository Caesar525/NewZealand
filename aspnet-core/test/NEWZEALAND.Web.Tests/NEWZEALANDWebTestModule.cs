using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NEWZEALAND.EntityFrameworkCore;
using NEWZEALAND.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace NEWZEALAND.Web.Tests
{
    [DependsOn(
        typeof(NEWZEALANDWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class NEWZEALANDWebTestModule : AbpModule
    {
        public NEWZEALANDWebTestModule(NEWZEALANDEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NEWZEALANDWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(NEWZEALANDWebMvcModule).Assembly);
        }
    }
}