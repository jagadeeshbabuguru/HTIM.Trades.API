using HTIM.Trades.Model;
using Microsoft.Extensions.Configuration;

namespace HTIM.Trades.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private IConfiguration? Configuration { get; set; }
        public ConfigurationService(IConfiguration config)
        {
            string ConnectionString = config.GetSection("SqlConnection").Value;
        }      
        public ApplicationSettings GetAppSettings(IConfiguration config)
        {
            ApplicationSettings appSettings = new ApplicationSettings();
            appSettings.ConnectionString = config.GetSection("SqlConnection").Value;
            return appSettings;           
        }

        public ApplicationSettings GetAppSettings()
        {
            throw new NotImplementedException();
        }
    }
}