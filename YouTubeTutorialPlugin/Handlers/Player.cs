using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace YouTubeTutorialPlugin.Handlers
{
	class Player
	{
		public void OnLeft(LeftEventArgs ev)
		{
			string message =
				YouTubeTutorialPlugin.Instance.Config.LeftMessage.Replace("{player}", ev.Player.Nickname);
			Map.Broadcast(6, message);
		}

		public void OnJoined(JoinedEventArgs ev)
		{
			string message =
				YouTubeTutorialPlugin.Instance.Config.JoinedMessage.Replace("{player}", ev.Player.Nickname);
			Map.Broadcast(6, message);
		}

		public void OnInteractingDoor(InteractingDoorEventArgs ev)
		{
			if (ev.IsAllowed == false)
			{
				ev.Player.Broadcast(3, YouTubeTutorialPlugin.Instance.Config.BoobyTrapMessage);
				ev.Player.Kill(DamageTypes.Lure);
			}
		}
	}
}
