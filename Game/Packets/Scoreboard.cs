using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Packets {
    class Scoreboard : Core.Networking.OutPacket {
        public Scoreboard(Entities.Room r)
            : base((ushort)Enums.Packets.Scoreboard) {

                Append2(Core.Constants.Error_OK);

                if (r.Mode == Enums.Mode.Explosive) {
                    Append2(r.CurrentGameMode.CurrentRoundTeamA());
                    Append2(r.CurrentGameMode.CurrentRoundTeamB());
                } else {
                    Append2(0);
                    Append2(0);
                }

                Append2(r.CurrentGameMode.ScoreboardA());
                Append2(r.CurrentGameMode.ScoreboardB());

                Entities.Player[] players = r.Players.Values.Where(p => p != null).ToArray();
                Append2(players.Length);
                foreach (Entities.Player p in players) {
                    Append2(p.Id);
                    Append2(p.Kills);
                    Append2(p.Deaths);
                    Append2(p.Flags);
                    Append2(p.Assists + p.Points);
                    Append2(0);
                }

        }
    }
}
