namespace Game.Packets {
    class MapData : Core.Networking.OutPacket {
        public MapData(Entities.Room r)
            : base((ushort)Enums.Packets.MapData) {
                Append2(Core.Constants.Error_OK);

                sbyte[] flags = r.Flags;
                Append2(flags.Length);
                for (byte i = 0; i < flags.Length; i++) 
                    Append2(flags[i]);
                Append2(900); // ?

                lock (r._playerLock) {
                    Append2(r.Players.Count);
                    foreach (Entities.Player p in r.Players.Values) {
                        Append2(p.Id); // Slot
                        Append2(-1); // ?
                        Append2(p.Kills); // Kills
                        Append2(p.Deaths); // Deaths
                        Append2((byte)p.Class); // Class
                        Append2(p.Health);
                        Append2(-1); // Vehicle ID
                        Append2(-1); // Vehicle Seat
                    }
                }

            // TODO: Moved Vehicles :)
                Append2(0);
        }
    }
}
