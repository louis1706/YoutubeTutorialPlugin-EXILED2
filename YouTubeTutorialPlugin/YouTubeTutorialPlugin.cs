using System;
using Exiled.API.Enums;
using Exiled.API.Features;

using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;

namespace YouTubeTutorialPlugin
{
    public class YouTubeTutorialPlugin : Plugin<Config>
    {
	    private static readonly Lazy<YouTubeTutorialPlugin> LazyInstance = new Lazy<YouTubeTutorialPlugin>(() => new YouTubeTutorialPlugin());
	    public static YouTubeTutorialPlugin Instance => LazyInstance.Value;

	    public override PluginPriority Priority { get; } = PluginPriority.Medium;

	    private Handlers.Server server;
	    private Handlers.Player player;

		private YouTubeTutorialPlugin()
	    {
	    }

		public override void OnEnabled()
		{
			RegisterEvents();
		}

		public override void OnDisabled()
		{
			UnregisterEvents();
		}

		private void RegisterEvents()
		{
			server = new Handlers.Server();
			player = new Handlers.Player();

			Player.Left += player.OnLeft;
			Player.Joined += player.OnJoined;
			Player.InteractingDoor += player.OnInteractingDoor;

			Server.WaitingForPlayers += server.OnWaitingForPlayers;
			Server.RoundStarted += server.OnRoundStarted;
		}

		private void UnregisterEvents()
		{
			Player.Left -= player.OnLeft;
			Player.Joined -= player.OnJoined;
			Player.InteractingDoor -= player.OnInteractingDoor;

			Server.WaitingForPlayers -= server.OnWaitingForPlayers;
			Server.RoundStarted -= server.OnRoundStarted;

			server = null;
			player = null;
		}
	}
}
