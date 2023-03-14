using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace NEWZEALAND.EntityFrameworkCore
{
    public static class NEWZEALANDDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<NEWZEALANDDbContext> builder, string connectionString)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));
            //builder.UseMySql(connectionString, serverVersion).ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryPossibleUnintendedUseOfEqualsWarning));
            builder.UseMySql(connectionString, serverVersion);
            //builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<NEWZEALANDDbContext> builder, DbConnection connection)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));
            //builder.UseMySql(connection, serverVersion).ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryPossibleUnintendedUseOfEqualsWarning));
            builder.UseMySql(connection, serverVersion);
            //builder.UseSqlServer(connection);
        }
    }
}
