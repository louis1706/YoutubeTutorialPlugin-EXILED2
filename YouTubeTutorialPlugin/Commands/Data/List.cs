using System;
using System.Collections.Generic;
using System.Text;
using CommandSystem;
using Exiled.API.Features;
using YouTubeTutorialPlugin.Api;

namespace YouTubeTutorialPlugin.Commands
{
	class List : ICommand
	{
		public string Command { get; } = "list";

		public string[] Aliases { get; } = { "ls" };

		public string Description { get; } = "A command that lists all the player data.";

		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			var sb = new StringBuilder("PlayerData:\n");

			foreach (KeyValuePair<string, PlayerData> data in YouTubeTutorialPlugin.PlayerData)
			{
				sb.AppendLine($"Player: {Player.Get(data.Key).Nickname} ({data.Key})");
				sb.AppendLine($"    - Kills: {data.Value.Kills}");
				sb.AppendLine($"    - Deaths: {data.Value.Deaths}");
				sb.AppendLine($"    - Rounds Played: {data.Value.RoundsPlayed}");
				sb.AppendLine($"    - Door Interactions: {data.Value.DoorInteractions}");
			}

			response = sb.ToString();
			return true;
		}
	}
}