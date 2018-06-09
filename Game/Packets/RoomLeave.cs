namespace Game.Packets {
    class RoomLeave : Core.Networking.OutPacket {
        public RoomLeave(Entities.User u, byte oldSlot,  Entities.Room r)
            : base((ushort)Enums.Packets.RoomLeave) {
            Append2(Core.Constants.Error_OK);
            Append2(u.SessionID); // SessionID
            Append2(oldSlot); // Position in Room
            Append2(r.Players.Count); // Remaining player count
            Append2(r.Master); // Master Slot
            Append2(u.XP); // XP
            Append2(u.Money); // Dinar
        }
    }
}
