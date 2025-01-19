using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeTutorialPlugin
{
    public sealed class Translation : ITranslation
    {
        [Description("Sets the message for when someone joins the server. {player} will be replaced with the players name.")]
        public string JoinedMessage { get; set; } = "{player} has joined the server.";

        [Description("Sets the message for when someone leaves the server. {player} will be replaced with the players name.")]
        public string LeftMessage { get; set; } = "{player} has left the server.";

        [Description("Sets the message to be played when a round has been started.")]
        public string RoundStartedMessage { get; set; } = "Get ready for carnage!";

        [Description("Sets the message for when someone triggers a booby trap.")]
        public string BoobyTrapMessage { get; set; } = "This door has been booby trapped!";
    }
}
