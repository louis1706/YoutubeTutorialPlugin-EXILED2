using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Loader;
using HarmonyLib;
using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;

namespace YouTubeTutorialPlugin
{
    public class YouTubeTutorialPlugin : Plugin<Config>
    {
		public static YouTubeTutorialPlugin Instance { get; } = new YouTubeTutorialPlugin();
		private YouTubeTutorialPlugin() { }

		public override PluginPriority Priority { get; } = PluginPriority.Medium;

	    private Handlers.Server server;
	    private Handlers.Player player;

	    private int _patchesCounter;

	    public Harmony Harmony { get; private set; }

		public override void OnEnabled()
		{
			base.OnEnabled();

			RegisterEvents();
			Patch();
		}

		public override void OnDisabled()
		{
			base.OnDisabled();

			UnregisterEvents();
			Unpatch();
		}

		private void Patch()
		{
			try
			{
				Harmony = new Harmony($"youtube.tutorialplugin.{++_patchesCounter}");

				var lastDebugStatus = Harmony.DEBUG;
				Harmony.DEBUG = true;

				Harmony.PatchAll();

				Harmony.DEBUG = lastDebugStatus;

				Log.Debug("Patches applied successfully!", Loader.ShouldDebugBeShown);
			}
			catch (Exception e)
			{
				Log.Error($"Patching failed {e}");
			}
		}

		private void Unpatch()
		{
			Harmony.UnpatchAll();

			Log.Debug("Patches have been undone!", Loader.ShouldDebugBeShown);
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
