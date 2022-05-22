using LearnIt.MAUI.Constants;
using Microsoft.Extensions.Configuration;

namespace LearnIt.MAUI.Services
{
    public class ConfigurationService
    {
        private readonly IConfiguration _configuration;

        public ConfigurationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool IsDevelopment()
        {
            return _configuration[EnviromentConstants.ENVIROMENT_KEY] == EnviromentConstants.DEVELOPMENT_KEY;
        }

        public bool IsProduction()
        {
            return _configuration[EnviromentConstants.ENVIROMENT_KEY] == EnviromentConstants.PRODUCTION_KEY;
        }
    }
}