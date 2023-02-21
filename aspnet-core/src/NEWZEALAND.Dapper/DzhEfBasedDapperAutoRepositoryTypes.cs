using Abp.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEWZEALAND.Dapper
{
    public class DzhEfBasedDapperAutoRepositoryTypes
    {
        static DzhEfBasedDapperAutoRepositoryTypes()
        {
            Default = new DapperAutoRepositoryTypeAttribute(
                typeof(IDzhDapperRepository<>),
                typeof(IDzhDapperRepository<,>),
                typeof(DzhDapperEfRepositoryBase<,>),
                typeof(DzhDapperEfRepositoryBase<,,>)
            );
        }

        public static DapperAutoRepositoryTypeAttribute Default { get; }
    }
}
