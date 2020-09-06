using System;
using System.Collections.Generic;
using CommandSystem;
using YouTubeTutorialPlugin.Api;

namespace YouTubeTutorialPlugin.Commands
{
	class Save : ICommand
	{
		public string Command { get; } = "save";

		public string[] Aliases { get; } = { "s" };

		public string Description { get; } = "A command that saves all the player data.";

		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			var count = 0;
			foreach (KeyValuePair<string, PlayerData> data in YouTubeTutorialPlugin.PlayerData)
			{
				data.Value.SaveData(data.Key);
				count++;
			}

			response = $"Successfully saved {count} players.";
			return true;
		}
	}
}