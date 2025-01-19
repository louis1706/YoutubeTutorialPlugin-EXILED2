using System.ComponentModel;
using Exiled.API.Interfaces;

namespace YouTubeTutorialPlugin
{
	public sealed class Config : IConfig
	{
		[Description("Determines if the plugin should be enabled or disabled.")]
		public bool IsEnabled { get; set; } = true;

        [Description("Whether debug messages should be shown in the console.")]
        public bool Debug { get; set; } = true;

		[Description(
			"Amount of time to cache players after they have left. (Best to keep resonable to avoid disk read on round restarts)")]
		public float PlayerCacheTime { get; set; } = 120;
	}
}
