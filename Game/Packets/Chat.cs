namespace Game.Packets {
    class Chat : Core.Networking.OutPacket {
        public Chat(Entities.User u, Enums.ChatType type, string message, int targetId, string targetName)
            : base((ushort)Enums.Packets.Chat) {
            Append2(Core.Constants.Error_OK);
            Append2(u.SessionID);
            Append2(u.Displayname);
            Append2((byte)type);
            Append2(targetId);
            Append2(targetName);
            Append2(message);
        }

        public Chat(string name, Enums.ChatType type, string message, int targetId, string targetName)
            : base((ushort)Enums.Packets.Chat) {
            Append2(Core.Constants.Error_OK);
            Append2(0);
            Append2(name);
            Append2((byte)type);
            Append2(targetId);
            Append2(targetName);
            Append2(message);
        }
        public Chat(int _error, string targetName)
            : base((ushort)Enums.Packets.Chat)
        {
            targetName = targetName + " ";
            Append2(_error);
            Append2(targetName);

        }
        
    }
}
