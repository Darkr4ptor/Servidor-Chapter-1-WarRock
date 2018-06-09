using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Packets
{
    class LeaveVehicle : Core.Networking.OutPacket
    {
        public LeaveVehicle(byte _vehicleID, string oddString) : base(29969)
        {
            Append2(_vehicleID);
            Append2(-1);
            Append2(-1);
            Append2(-1);
            Append2(-1);
            Append2(-1);
            Append2(-1);
            Append2(-1);
            Append2(oddString);
            Append2(-1);
            Append2(-1);
            Append2(-1);
            Append2(-1);
            Append2(-1);
            Append2(-1);
            Append2(-1);
            Append2(-1);
            Append2(-1);
        }
    }
}
