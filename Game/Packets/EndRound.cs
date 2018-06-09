using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Packets {
    class EndRound : Core.Networking.OutPacket {
        public EndRound(Entities.Room r, Enums.Team winningTeam)
            : base((ushort)Enums.Packets.GamePacket) {
            Append2(1);
            Append2(-1);
            Append2(r.ID);
            Append2(1);
            Append2(6); // TYPE
            Append2(0); // ?
            Append2(1); // ?
            Append2((byte)winningTeam); // Winning Team ID
            Append2(r.CurrentGameMode.CurrentRoundTeamA());
            Append2(r.CurrentGameMode.CurrentRoundTeamB());
            Append2(5); // Remaining Rounds?
            Append2(0);
            Append2(92);
            Append2(-1);
            Append2(0);
            Append2(0);
            Append2(1200000);
            Append2(-900000);
            Append2(1200000);
            Append2("0.0000");
            Append2("0.0000");
            Append2("0.0000");
            Append2("0.0000");
            Append2("0.0000");
            Append2("0.0000");
            Append2(0);
            Append2(0);
            Append2("DS05");
        }
    }
}
