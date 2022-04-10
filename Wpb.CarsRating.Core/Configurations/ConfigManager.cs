using Microsoft.Extensions.Configuration;
using System.IO;

namespace Wpb.CarsRating.Core.Configurations
{
    public class ConfigManager
    {
		public string GetSetting(string settingName)
		{
			return GetFromAppSettings(settingName);
		}

		private string GetFromAppSettings(string settingName)
		{
			var config = InitializeConfiguration();
			return config[settingName];
		}

		private static IConfigurationRoot InitializeConfiguration()
		{
			var configBuilder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");
			var config = configBuilder.Build();
			return config;
		}
	}
}
