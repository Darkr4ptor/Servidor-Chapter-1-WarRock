namespace Game.Packets {
    class LevelUp : Core.Networking.OutPacket {
        public LevelUp(Entities.User u, uint dinarEarned)
            : base((ushort)Enums.Packets.LevelUp) {
            Append2(u.RoomSlot);
            Append2(0);
            Append2(Core.LevelCalculator.GetLevelforExp(u.XP));
            Append2(u.XP);
            Append2(dinarEarned);
        }
    }
}
