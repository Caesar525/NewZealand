using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using NEWZEALAND.Authorization.Roles;
using NEWZEALAND.Authorization.Users;
using NEWZEALAND.MultiTenancy;
using System.Threading.Tasks;
using System.Threading;
using NEWZEALAND.Domain;
using NEWZEALAND.Runtimes;
using Abp.Extensions;

namespace NEWZEALAND.EntityFrameworkCore
{
    public class NEWZEALANDDbContext : AbpZeroDbContext<Tenant, Role, User, NEWZEALANDDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public NEWZEALANDDbContext(DbContextOptions<NEWZEALANDDbContext> options)
            : base(options)
        {
        }

        public DbSet<NZ_CONSUME> NZ_CONSUME { get; set; }
        public DbSet<NZ_CONSUMELIST> NZ_CONSUMELIST { get; set; }
        public DbSet<NZ_INCOMELIST> NZ_INCOMELIST { get; set; }
        public DbSet<NZ_MATERIALS> NZ_MATERIALS { get; set; }
        public DbSet<NZ_MATERIALSLIST> NZ_MATERIALSLIST { get; set; }
        public DbSet<NZ_BUDGETPOOL> NZ_BUDGETPOOL { get; set; }

        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSaving()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        if (entry.Entity is IHasCreateUserName)
                        {
                            entry.Entity.As<IHasCreateUserName>().CreateUserName = AbpSession.GetUserName();
                        }
                        break;

                    case EntityState.Modified:
                        if (entry.Entity is IHasUpdateUserName)
                        {
                            entry.Entity.As<IHasUpdateUserName>().UpdateUserName = AbpSession.GetUserName();
                        }
                        break;

                    case EntityState.Deleted:
                        if (entry.Entity is IHasDeleteUserName)
                        {
                            entry.Entity.As<IHasDeleteUserName>().DeleteUserName = AbpSession.GetUserName();
                        }
                        break;
                }
            }
        }
    }
}

