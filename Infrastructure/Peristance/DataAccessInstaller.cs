using Contract.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Peristance.Repository;

namespace Peristance
{
    public static class DataAccessInstaller
    {
        public static void AddDataAccess(this IServiceCollection services, string connectionString)
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();

            connectionStringBuilder.ConnectionString = connectionString;
            connectionStringBuilder.IntegratedSecurity = true;
            connectionStringBuilder.Encrypt = false;
            connectionStringBuilder.TrustServerCertificate = false;
            connectionStringBuilder.ApplicationIntent = ApplicationIntent.ReadWrite;
            connectionStringBuilder.MultiSubnetFailover = false;

            services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionStringBuilder.ConnectionString));

            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}