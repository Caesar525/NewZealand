using Abp.Dapper.Repositories;
using Abp.Data;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEWZEALAND.Dapper
{
    public class DzhDapperEfRepositoryBase<TDbContext, TEntity> :
        DzhDapperEfRepositoryBase<TDbContext, TEntity, int>, IDzhDapperRepository<TEntity>
        where TEntity : class, IEntity<int>
        where TDbContext : class
    {
        public DzhDapperEfRepositoryBase(IActiveTransactionProvider activeTransactionProvider) : base(activeTransactionProvider)
        {
        }

    }

    public class DzhDapperEfRepositoryBase<TDbContext, TEntity, TPrimaryKey> :
         DapperRepositoryBase<TEntity, TPrimaryKey>, IDzhDapperRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>

    {
        private readonly IActiveTransactionProvider _activeTransactionProvider;

        public DzhDapperEfRepositoryBase(IActiveTransactionProvider activeTransactionProvider) : base(activeTransactionProvider)
        {
            _activeTransactionProvider = activeTransactionProvider;
        }

        public ActiveTransactionProviderArgs ActiveTransactionProviderArgs
        {
            get
            {
                return new ActiveTransactionProviderArgs
                {
                    ["ContextType"] = typeof(TDbContext),
                    ["MultiTenancySide"] = MultiTenancySide
                };
            }
        }

        public DbConnection Connection => (DbConnection)_activeTransactionProvider.GetActiveConnection(ActiveTransactionProviderArgs);

        public DbTransaction ActiveTransaction => (DbTransaction)_activeTransactionProvider.GetActiveTransaction(ActiveTransactionProviderArgs);

    }
}
