using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;
using HTIM.Trades.Data;
using HTIM.Trades.Services;

namespace HTIM.Trades.Services
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddServiceAccessInterface(this IServiceCollection services,
            IConfiguration configuration)
        {            
            services.AddSingleton<ITradesRepo, TradesRepo>(provider =>
            {
                var connectionString = configuration.GetConnectionString("SqlConnection");
                var connection = new SqlConnection(connectionString);
                return new TradesRepo(connection);
            });
            services.AddTransient<ITradesService, TradesService>();
            return services;
        }
    }
}
