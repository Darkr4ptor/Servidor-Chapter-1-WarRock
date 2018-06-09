namespace Game.Packets
{
    class RoomKick : Core.Networking.OutPacket
    {
        public RoomKick(int _playerSeat)
            : base((ushort)Enums.Packets.RoomKick)
        {
            Append2(1);
            Append2(_playerSeat);
        }
    }
}
