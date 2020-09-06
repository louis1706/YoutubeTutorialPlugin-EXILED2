using Exiled.API.Features;
using YouTubeTutorialPlugin.Api;

namespace YouTubeTutorialPlugin.Handlers
{
	class Server
	{
		public void OnWaitingForPlayers()
		{
			Log.Info("Waiting for players...");
		}

		public void OnRoundStarted()
		{
			Map.Broadcast(6, YouTubeTutorialPlugin.Instance.Config.RoundStartedMessage);
			Log.Info(YouTubeTutorialPlugin.Instance.Config.RoundStartedMessage);

			foreach (Exiled.API.Features.Player player in Exiled.API.Features.Player.List)
			{
				YouTubeTutorialPlugin.PlayerData.GetOrAdd(player.UserId, () => new PlayerData()).RoundsPlayed++;
			}
		}
	}
}
