using Exiled.API.Features;
using YouTubeTutorialPlugin.Api;

namespace YouTubeTutorialPlugin.Handlers
{
	internal class Server
	{
		public static void OnWaitingForPlayers()
		{
			Log.Info("Waiting for players...");
		}

		public static void OnRoundStarted()
		{
			Map.Broadcast(6, YouTubeTutorialPlugin.Instance.Translation.RoundStartedMessage);
			Log.Info(YouTubeTutorialPlugin.Instance.Translation.RoundStartedMessage);

			foreach (Exiled.API.Features.Player player in Exiled.API.Features.Player.List)
			{
				YouTubeTutorialPlugin.PlayerData.GetOrAdd(player.UserId, () => new PlayerData()).RoundsPlayed++;
			}
		}
	}
}
