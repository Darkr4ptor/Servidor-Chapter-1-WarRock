using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Packets {
    class StartRound : Core.Networking.OutPacket {
        public StartRound(Entities.Room r)
            : base((ushort)Enums.Packets.GamePacket) {
            Append2(1);
            Append2(-1);
            Append2(r.ID);
            Append2(1);
            Append2(5); // TYPE
            Append2(0);
            Append2(r.CurrentGameMode.CurrentRoundTeamA());
            Append2(r.CurrentGameMode.CurrentRoundTeamB());
            Append2(1);
            Append2(0);
            Append2(5);
            Append2(0);
            Append2(0);
            Append2(-1);
            Append2(0);
            Append2(0);
            Append2(800000);
            Append2(-184460);
            Append2(800000);
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
