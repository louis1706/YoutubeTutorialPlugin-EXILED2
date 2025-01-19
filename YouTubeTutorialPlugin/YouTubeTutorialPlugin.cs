using System;
using System.Collections.Generic;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Loader;
using HarmonyLib;
using YouTubeTutorialPlugin.Api;
using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;

namespace YouTubeTutorialPlugin
{
    public class YouTubeTutorialPlugin : Plugin<Config, Translation>
    {
		public static YouTubeTutorialPlugin Instance { get; } = new YouTubeTutorialPlugin();
		private YouTubeTutorialPlugin() { }

		public override PluginPriority Priority { get; } = PluginPriority.Medium;

	    private Handlers.Server server;
	    private Handlers.Player player;

	    public static readonly Dictionary<string, PlayerData> PlayerData = new Dictionary<string, PlayerData>();

	    private int _patchesCounter;

	    private Harmony Harmony { get; set; }

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

				bool lastDebugStatus = Harmony.DEBUG;
				Harmony.DEBUG = true;

				Harmony.PatchAll();

				Harmony.DEBUG = lastDebugStatus;

				Log.Debug("Patches applied successfully!");
			}
			catch (Exception e)
			{
				Log.Error($"Patching failed {e}");
			}
		}

		private void Unpatch()
		{
			Harmony.UnpatchAll();

			Log.Debug("Patches have been undone!");
		}

		private void RegisterEvents()
		{
			server = new Handlers.Server();
			player = new Handlers.Player();

			Player.Destroying += Handlers.Player.OnDestroying;
			Player.Verified += Handlers.Player.OnVerified;
			Player.InteractingDoor += Handlers.Player.OnInteractingDoor;
			Player.Died += Handlers.Player.OnPlayerDied;

			Server.WaitingForPlayers += Handlers.Server.OnWaitingForPlayers;
			Server.RoundStarted += Handlers.Server.OnRoundStarted;
		}

		private void UnregisterEvents()
		{
            Player.Destroying -= Handlers.Player.OnDestroying;
            Player.Verified -= Handlers.Player.OnVerified;
            Player.InteractingDoor -= Handlers.Player.OnInteractingDoor;
			Player.Died -= Handlers.Player.OnPlayerDied;

			Server.WaitingForPlayers -= Handlers.Server.OnWaitingForPlayers;
			Server.RoundStarted -= Handlers.Server.OnRoundStarted;

			server = null;
			player = null;
		}
	}
}
