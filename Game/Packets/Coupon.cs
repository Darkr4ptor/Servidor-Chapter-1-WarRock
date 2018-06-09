using Game.Enums;

namespace Game.Packets
{
    class Coupon : Core.Networking.OutPacket
    {

        public Coupon(int _success, uint _dinars)
            : base(30992)
        {
            Append2(_success);//-1 = code alrady registered   0 = success!              
            Append2(0); //??
            Append2(_dinars); //Dinars total
        }
    }
}
