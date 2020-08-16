using Exiled.API.Features;

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
		}
	}
}
