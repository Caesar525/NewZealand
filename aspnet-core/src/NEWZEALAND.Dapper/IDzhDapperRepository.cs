using Abp.Dapper.Repositories;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEWZEALAND.Dapper
{
    public interface IDzhDapperRepository<TEntity> : IDzhDapperRepository<TEntity, int> where TEntity : class, IEntity<int>
    {

    }

    public interface IDzhDapperRepository<TEntity, TPrimaryKey> : IDapperRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        DbConnection Connection { get; }
        DbTransaction ActiveTransaction { get; }
    }
}
