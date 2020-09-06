using System.Linq;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using YouTubeTutorialPlugin.Api;

namespace YouTubeTutorialPlugin.Handlers
{
	class Player
	{
		public void OnLeft(LeftEventArgs ev)
		{
			string message =
				YouTubeTutorialPlugin.Instance.Config.LeftMessage.Replace("{player}", ev.Player.Nickname);
			Map.Broadcast(6, message);

			Timing.CallDelayed(YouTubeTutorialPlugin.Instance.Config.PlayerCacheTime, () => RemovePlayer(ev.Player));
		}

		private void RemovePlayer(Exiled.API.Features.Player player)
		{
			if (!Exiled.API.Features.Player.UserIdsCache.ContainsKey(player.UserId) && YouTubeTutorialPlugin.PlayerData.ContainsKey(player.UserId))
			{
				YouTubeTutorialPlugin.PlayerData.GetOrAdd(player.UserId, () => new PlayerData()).SaveData(player.UserId);
				YouTubeTutorialPlugin.PlayerData.Remove(player.UserId);
				Log.Debug($"Player: {player.Nickname} has been stored to disk.");
			}
		}

		public void OnJoined(JoinedEventArgs ev)
		{
			string message =
				YouTubeTutorialPlugin.Instance.Config.JoinedMessage.Replace("{player}", ev.Player.Nickname);
			Map.Broadcast(6, message);

			PlayerData.LoadData(ev.Player.UserId);
		}

		public void OnPlayerDied(DiedEventArgs ev)
		{
			if (ev.Killer != null)
			{
				YouTubeTutorialPlugin.PlayerData.GetOrAdd(ev.Killer.UserId, () => new PlayerData()).Kills++;
			}

			if (ev.Target != null)
			{
				YouTubeTutorialPlugin.PlayerData.GetOrAdd(ev.Target.UserId, () => new PlayerData()).Deaths++;
			}
		}

		public void OnInteractingDoor(InteractingDoorEventArgs ev)
		{
			if (ev.IsAllowed == false)
			{
				ev.Player.Broadcast(3, YouTubeTutorialPlugin.Instance.Config.BoobyTrapMessage);
				ev.Player.Kill(DamageTypes.Lure);
			}
			else
			{
				YouTubeTutorialPlugin.PlayerData.GetOrAdd(ev.Player.UserId, () => new PlayerData()).DoorInteractions++;
			}
		}
	}
}
