using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace NEWZEALAND.EntityFrameworkCore
{
    public static class NEWZEALANDDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<NEWZEALANDDbContext> builder, string connectionString)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 24));
            builder.UseMySql(connectionString, serverVersion);
            //builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<NEWZEALANDDbContext> builder, DbConnection connection)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 24));
            builder.UseMySql(connection, serverVersion);
            //builder.UseSqlServer(connection);
        }
    }
}
