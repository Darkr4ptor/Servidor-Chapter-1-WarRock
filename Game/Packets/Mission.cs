using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Packets {
    class Mission : Core.Networking.OutPacket {
        public Mission(Entities.Room r)
            : base(30000) {
            Append2(1); // Success
            Append2(-1); // ??
            Append2(r.ID); // Room ID
            Append2(2);
            Append2(403); // Sub id?
            Append2(0);
            Append2(1);
            Append2(3);
            Append2(363);
            Append2(0);
            Append2(1);
            Append2(0);
            Append2(0);
            Append2(0);
            Append2(0);
        }
    }
}
