namespace Game.Packets {
    class GameTick : Core.Networking.OutPacket {
        public GameTick(Entities.Room r)
            : 
            base((ushort)Enums.Packets.GameTick) {
            Append2(r.UpTick); // Spawn Counter
            Append2(r.DownTick); // Time Left
            Append2(r.CurrentGameMode.CurrentRoundTeamA());
            Append2(r.CurrentGameMode.CurrentRoundTeamB());
            Append2(r.CurrentGameMode.ScoreboardA());
            Append2(r.CurrentGameMode.ScoreboardB());
            Append2(2); // ?
            Append2(0); // Conquest related
            Append2(30); // Conquest related
        }
    }
}
