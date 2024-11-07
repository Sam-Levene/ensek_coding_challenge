using Microsoft.Extensions.Configuration;

namespace ensek_coding_challenge.AppConfig
{
    public static class Config
    {
        public static string BaseUrl { get; private set; }
        public static string Browser { get; private set; }

        static Config()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            BaseUrl = configuration["BaseUrl"];
            Browser = configuration["Browser"];
        }
    }
}
