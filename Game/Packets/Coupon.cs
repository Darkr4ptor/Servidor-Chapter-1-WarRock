﻿using Game.Enums;

namespace Game.Packets
{
    class Coupon : Core.Networking.OutPacket
    {

        public Coupon(int _success, uint _dinars)
            : base(30992)
        {
            Append(_success);//-1 = code already registered   0 = success!              
            Append(0); //??
            Append(_dinars); //Dinars total
        }
    }
}
