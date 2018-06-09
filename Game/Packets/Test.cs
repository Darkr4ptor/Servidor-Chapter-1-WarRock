namespace Game.Packets
{
    class Test : Core.Networking.OutPacket
    {
        public Test(Entities.Room Room)
            : base((ushort)Enums.Packets.GamePacket)
        {
            Append2(1);
            Append2(0);
            Append2(0);
            Append2(2);
            Append2(51);
            Append2(1);
            Append2(0);
            Append2(Room.Map);
            Append2(0);
            Append2(0);
            Append2(0);
            Append2(0);
            Append2(0);
            Append2(0);
            Append2(0);

        }
    }
}
