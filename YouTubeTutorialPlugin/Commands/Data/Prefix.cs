using System;
using System.Collections.Generic;
using System.Text;
using CommandSystem;
using HarmonyLib;

namespace YouTubeTutorialPlugin.Commands.Data
{
	[CommandHandler(typeof(RemoteAdminCommandHandler))]
	class Prefix : ParentCommand
	{
		public Prefix() => LoadGeneratedCommands();

		public override void LoadGeneratedCommands()
		{
			RegisterCommand(new List());
			RegisterCommand(new Save());
		}

		protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			var sb = new StringBuilder("Available commands:\n");

			foreach (KeyValuePair<string, ICommand> command in this.Commands)
			{
				sb.AppendLine($"- {Command} {command.Value.Command} (Aliases: {command.Value.Aliases.Join()})");
			}

			response = sb.ToString();
			return false;
		}

		public override string Command { get; } = "data";
		public override string[] Aliases { get; } = new String[] { };
		public override string Description { get; } = "Handles commands related to player data.";
	}
}
