using IveComeToBook.Domain.Repositories.User;
using IveComeToBook.Infrastructure.DataAcess;
using IveComeToBook.Infrastructure.DataAcess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IveComeToBook.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            AddDbContext_SqlServer(services);
            AddRepositories(services);
        }

        private static void AddDbContext_SqlServer(IServiceCollection services)
        {
            var connectionString = "Data Source=TECNOSEG;Initial Catalog=ivecometobook;User ID=sa;Password=123;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True";

            services.AddDbContext<IveComeToBookDbContext>(dbContextOptions =>
            {
                dbContextOptions.UseSqlServer(connectionString);
            });
        }

        private static void AddDbContext_MySqlServer(IServiceCollection services)
        {
            var connectionString = "Server=locahost;Database=ivecometobook;User=root;Password=88331614";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 16));
            services.AddDbContext<IveComeToBookDbContext>(dbContextOptions =>
            {
                dbContextOptions.UseMySql(connectionString, serverVersion);
            });
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserReadOnlyRepository, UserRepository > ();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository > ();
        }
    }
}
