using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NEWZEALAND.Configuration;

namespace NEWZEALAND.Web.Host.Startup
{
    [DependsOn(
       typeof(NEWZEALANDWebCoreModule))]
    public class NEWZEALANDWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public NEWZEALANDWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NEWZEALANDWebHostModule).GetAssembly());
        }
    }
}
