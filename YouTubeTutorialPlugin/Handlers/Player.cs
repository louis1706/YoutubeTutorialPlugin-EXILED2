using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.Events.EventArgs.Player;
using MEC;
using YouTubeTutorialPlugin.Api;

namespace YouTubeTutorialPlugin.Handlers
{
	internal class Player
	{
		public static void OnDestroying(DestroyingEventArgs ev)
		{
			string message =
				YouTubeTutorialPlugin.Instance.Translation.LeftMessage.Replace("{player}", ev.Player.Nickname);
			Map.Broadcast(6, message);

			Timing.CallDelayed(YouTubeTutorialPlugin.Instance.Config.PlayerCacheTime, () => RemovePlayer(ev.Player));
		}

		private static void RemovePlayer(Exiled.API.Features.Player player)
		{
			if (!Exiled.API.Features.Player.UserIdsCache.ContainsKey(player.UserId) && YouTubeTutorialPlugin.PlayerData.ContainsKey(player.UserId))
			{
				YouTubeTutorialPlugin.PlayerData.GetOrAdd(player.UserId, () => new PlayerData()).SaveData(player.UserId);
				YouTubeTutorialPlugin.PlayerData.Remove(player.UserId);
				Log.Debug($"Player: {player.Nickname} has been stored to disk.");
			}
		}

		public static void OnVerified(VerifiedEventArgs ev)
		{
			string message =
				YouTubeTutorialPlugin.Instance.Translation.JoinedMessage.Replace("{player}", ev.Player.Nickname);
			Map.Broadcast(6, message);

			PlayerData.LoadData(ev.Player.UserId);
		}

		public static void OnPlayerDied(DiedEventArgs ev)
		{
			if (ev.Attacker != null)
			{
				YouTubeTutorialPlugin.PlayerData.GetOrAdd(ev.Attacker.UserId, () => new PlayerData()).Kills++;
			}

			if (ev.Attacker != null)
			{
				YouTubeTutorialPlugin.PlayerData.GetOrAdd(ev.Attacker.UserId, () => new PlayerData()).Deaths++;
			}
		}

		public static void OnInteractingDoor(InteractingDoorEventArgs ev)
		{
			if (ev.IsAllowed == false)
			{
				ev.Player.Broadcast(3, YouTubeTutorialPlugin.Instance.Translation.BoobyTrapMessage);
				ev.Player.Kill("Custom Death");
			}
			else
			{
				YouTubeTutorialPlugin.PlayerData.GetOrAdd(ev.Player.UserId, () => new PlayerData()).DoorInteractions++;
			}
		}
	}
}
