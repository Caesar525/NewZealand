using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using DapperExtensions.Sql;
using NEWZEALAND.Dapper;
using NEWZEALAND.EntityFrameworkCore.Seed;
using System.Collections.Generic;
using System.Reflection;

namespace NEWZEALAND.EntityFrameworkCore
{
    [DependsOn(
        typeof(NEWZEALANDCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule)
        , typeof(NEWZEALANDDapperModule))]
    public class NEWZEALANDEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<NEWZEALANDDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        NEWZEALANDDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        NEWZEALANDDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NEWZEALANDEntityFrameworkModule).GetAssembly());
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new List<Assembly>{ typeof(NEWZEALANDEntityFrameworkModule).GetAssembly() });
            DapperExtensions.DapperExtensions.SqlDialect = new MySqlDialect();
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
