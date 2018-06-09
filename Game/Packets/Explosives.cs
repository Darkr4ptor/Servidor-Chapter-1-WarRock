namespace Game.Packets {
    class Explosives : Core.Networking.OutPacket {
        public Explosives(string[] blocks)
            : base((ushort)Enums.Packets.Explosives) {
                Append2(Core.Constants.Error_OK);
                for (byte i = 0; i < blocks.Length; i++)
                    Append2(blocks[i]);
                Append2(0);
        }
    }
}
