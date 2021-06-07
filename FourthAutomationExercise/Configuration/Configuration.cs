using Microsoft.Extensions.Configuration;

namespace Framework.Configuration
{
    public static class Configuration
    {
        public static IConfiguration Initialize
        {
            get
            {
                var config = new ConfigurationBuilder()
                .AddJsonFile(@"appSettings.json")
                .Build();
                return config;
            }
        }

        public static IConfigurationSection GetSection(string sectionKey)
        {
            return Initialize.GetSection(sectionKey);
        }

        public static IConfigurationSection Url => GetSection(nameof(Url));
    }
}
