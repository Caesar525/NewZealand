using Abp.Dapper;
using Abp.Dependency;
using Abp.Modules;
using Abp.Orm;
using Abp.Reflection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEWZEALAND.Dapper
{
    [DependsOn(typeof(AbpDapperModule))]
    public class NEWZEALANDDapperModule:AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpDapperModule).GetAssembly());

            using (IScopedIocResolver scope = IocManager.CreateScope())
            {
                ISecondaryOrmRegistrar[] additionalOrmRegistrars = scope.ResolveAll<ISecondaryOrmRegistrar>();

                foreach (ISecondaryOrmRegistrar registrar in additionalOrmRegistrars)
                {
                    registrar.RegisterRepositories(IocManager, DzhEfBasedDapperAutoRepositoryTypes.Default);
                }
            }
        }
    }
}
