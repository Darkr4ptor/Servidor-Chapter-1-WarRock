namespace Game.Packets {
    class RoomJoin : Core.Networking.OutPacket {

        public enum ErrorCodes : uint {
            GenericError = 94010,
            InvalidPassword = 94030,
            UsersExceeded = 94060,
            NotJoinDurningDataLoading = 94100,
            CalculatingResults = 94110,
            RoomIsFull = 94120,
            BadLevel = 94300,
            OnlyPremium = 94301
        }

        public RoomJoin(byte slot, Entities.Room r)
            : base((ushort)Enums.Packets.RoomJoin) {
            Append2(Core.Constants.Error_OK);
            Append2(slot);
            addRoomInfo(r);
        }

        public RoomJoin(ErrorCodes err)
            : base((ushort)Enums.Packets.RoomJoin) {
            Append2((uint)err);
        }

        private void addRoomInfo(Entities.Room r) {
            // ROOM INFORMATION //
            Append2(r.ID);                           // Room Id
            Append2(1);                              // ?
            Append2((byte)r.State);                  // Room state: 1 = Waiting | 2 = Playing
            Append2(r.Master);                       // The slot index of the room master.
            Append2(r.Displayname);                  // The name of the room that will displayed in the roomlist.
            Append2(r.HasPassword);                  // Tells the client if the room has a password.
            Append2(r.MaximumPlayers);               // The maximum player count that is allowed in the room.
            Append2(r.Players.Count);                // The current player count that is currently in the room.
            Append2(r.Map);                          // The current map that is selected.
            Append2((r.Mode == 0) ? r.Setting : 0);  // CQC Rounds
            Append2((r.Mode > 0) ? r.Setting : 0);   // FFA & TDM Kills
            Append2(0);                              // Time left?
            Append2((byte)r.Mode);                   // The current game mode of the room.
            Append2(4);                              // ?
            Append2(r.IsJoinable);                   // This is the join state of the room. 0 = Unjoinable | 1 = Joinable
            Append2(0);                              // ?
            Append2(r.Supermaster);                  // Does the room have the supermaster buf enabled? 0 = NO | 1 = YES
            Append2(r.Type);                         // Room Type, Unused in chapter 1.
            Append2(r.LevelLimit);                   // This is the value of the level limit.
            Append2(r.FriendlyFire);                  // Indicates if the room is a premium only room. 0 = NO | 1 = YES
            Append2(r.EnableVoteKick);               // Indicates if the vote kick function is enabled. 0 = NO | 1 = YES
            Append2(r.AutoStart);                    // Indicates if the auto start function is enabled. 0 = NO | 1 = YES
            Append2(0);                              // This was a number of average ping (before patch G1-17).
            Append2(r.PingLimit);                    // This is the value of the ping limit. 1 = GREEN , 2 = YELLOW, 3 = ALL.

            // CLAN BLOCK
            Append2(r.isClanWar);                 // Is clan war? -1 = NO  >0 = YES
            // IF ENABLED ADD 2 BLOCKS WITH BOTH OF THE CLAN IDS.
        }
    }
}
