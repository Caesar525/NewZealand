using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using NEWZEALAND.Authorization.Roles;
using NEWZEALAND.Authorization.Users;
using NEWZEALAND.MultiTenancy;

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
    }
}
