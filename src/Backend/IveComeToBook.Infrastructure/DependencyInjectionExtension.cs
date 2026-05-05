using IveComeToBook.Domain.Enums;
using IveComeToBook.Domain.Repositories;
using IveComeToBook.Domain.Repositories.User;
using IveComeToBook.Infrastructure.DataAcess;
using IveComeToBook.Infrastructure.DataAcess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IveComeToBook.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseType = configuration.GetConnectionString("DataBaseType");

            var databaseTypeEnum = (DatabaseType)Enum.Parse(typeof(DatabaseType), databaseType);
            
            if (databaseTypeEnum == DatabaseType.SqlServer)
            {
                AddDbContext_SqlServer(services, configuration);
            }
            else if (databaseTypeEnum == DatabaseType.MySql)
            {
                AddDbContext_MySqlServer(services, configuration);
            }
            else if (databaseTypeEnum == DatabaseType.PgSql)
            {
                AddDbContext_PgSqlServer(services, configuration);
            }
            AddRepositories(services);
        }

        private static void AddDbContext_SqlServer(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionSqlServer");

            services.AddDbContext<IveComeToBookDbContext>(dbContextOptions =>
            {
                dbContextOptions.UseSqlServer(connectionString);
            });
        }

        private static void AddDbContext_MySqlServer(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionMySql");
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 16));
            services.AddDbContext<IveComeToBookDbContext>(dbContextOptions =>
            {
                dbContextOptions.UseMySql(connectionString, serverVersion);
            });
        }

        private static void AddDbContext_PgSqlServer(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionPgSqlServer");

            services.AddDbContext<IveComeToBookDbContext>(dbContextOptions =>
            {
                dbContextOptions.UseNpgsql(connectionString);
            });
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserReadOnlyRepository, UserRepository > ();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository > ();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
