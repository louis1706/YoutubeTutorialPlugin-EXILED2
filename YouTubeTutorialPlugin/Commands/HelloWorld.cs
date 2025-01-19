using System;
using CommandSystem;
using RemoteAdmin;

namespace YouTubeTutorialPlugin.Commands
{
	[CommandHandler(typeof(RemoteAdminCommandHandler))]
	class HelloWorld : ICommand, IUsageProvider
	{
		public string Command { get; } = "hello";

		public string[] Aliases { get; } = new string[] { "helloworld" };

		public string Description { get; } = "A command that says hello to the world.";

        public string[] Usage => new[] { "Usage Provider" };

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			if (sender is PlayerCommandSender player)
			{
				response = $"Hello {player.Nickname}!";
				return false;
			}
			else
			{
				response = "World!";
				return true;
			}
		}
	}
}
