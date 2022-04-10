using System;

namespace Wpb.CarsRating.Core.Configurations
{
    public class AppSettings
	{
		public static class Api
		{
			private const string Domain = "Api";
			public static string Url => GetConfigManager().GetSetting($"{Domain}:Url");
		}
		public static class Web
		{
			private const string Domain = "Web";
			public static string Url => GetConfigManager().GetSetting($"{Domain}:Url");
			public static string TargetBrowser => GetConfigManager().GetSetting($"{Domain}:Target");
			public static string SeleniumGrid => GetConfigManager().GetSetting($"{Domain}:SeleniumGrid");
			public static TimeSpan TimeOut =>
				new TimeSpan(0, 0, Convert.ToInt16(GetConfigManager().GetSetting($"{Domain}:TimeOut")));
		}

		private static ConfigManager GetConfigManager()
		{
			return new ConfigManager();
		}
	}
}
