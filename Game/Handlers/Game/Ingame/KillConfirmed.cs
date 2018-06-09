using System;
using Game.Enums;
using Game.Networking;

namespace Game.Handlers.Game.Ingame
{
    internal class KillConfirmed : GameDataHandler
    {
        protected override void Handle() //TODO: DO SMTH MORE PRODUCTIVE WITH THIS
        {
            ServerLogger.Instance.Append2(ServerLogger.AlertLevel.Gaming, String.Concat("Player ", Player.User.Displayname, " has been killed"));
        }
    }
}
