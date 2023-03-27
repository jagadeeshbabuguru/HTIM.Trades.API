using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HTIM.Trades.Business.Facade;
using HTIM.Trades.Business.Interfaces;
using HTIM.Trades.Services;

namespace HTIM.Trades.Business
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddBussinessInterface(this IServiceCollection services, IConfiguration configuration)
        {
            // Facades
            services.AddTransient<ITradesFacade, TradesFacade>();
            services.AddServiceAccessInterface(configuration);
            return services;
        }
    }
}
