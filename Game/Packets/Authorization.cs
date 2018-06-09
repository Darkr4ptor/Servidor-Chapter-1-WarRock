using Game.Enums;

namespace Game.Packets {
    class Authorization : Core.Networking.OutPacket {
        public enum ErrorCodes : uint {
            NormalProcedure = 73030,    // Please log in using the normal procedure!
            InvalidPacket = 90100,      // Invalid Packet.
            UnregisteredUser = 90101,   // Unregistered User.
            AtLeast6Chars = 90102,      // You must type at least 6 characters .
            NicknameToShort = 90103,    // Nickname should be at least 6 charaters.
            IdInUseOtherServer = 90104, // Same ID is being used on the server.
            NotAccessible = 90105,      // Server is not accessible.
            TrainingServer = 90106,     // Trainee server is accesible until the rank of a private..
            ClanWarError = 90112,       // You cannot participate in Clan War
            LackOfResponse = 91010,     // Connection terminated because of lack of response for a while.
            ServerIsFull = 91020,       // You cannot connect. Server is full.
            InfoReqInTrafic = 91030,    // Info request are in traffic.
            AccountUpdateFailed = 91040,// Account update has failed.
            BadSynchronization = 91050, // User Info synchronization has failed.
            IdInUse = 92040,            // That ID is currently being used.
            PremiumOnly = 98010         // Available to Premium users only.
        }

        public Authorization(ErrorCodes errorCode) : base((ushort)Enums.Packets.Authorization) {
            Append2((uint)errorCode);
        }

        public Authorization(Entities.User u)
            : base((ushort)Enums.Packets.Authorization) {
                Append2(Core.Constants.Error_OK);
                Append2(string.Concat("Gameserver", Config.SERVER_ID));
                Append2(u.SessionID);
                Append2(u.ID);               // User id.
                Append2(u.SessionID);        // User session id.
                Append2(u.Displayname);      // User Displayname (Nickname).

            // CLAN BLOCKS //
            if(u.ClanId == -1)
                Fill(4, -1);
            else
            {
                Objects.Clan Clan = Managers.ClanManager.Instance.GetClan(u.ClanId);

                if(Clan != null)
                {
                    Append2(u.ClanId);
                    Append2(Clan.Name);
                    Append2(u.ClanRank);
                    Append2(u.ClanRank); 
                }
                else
                {
                    Log.Instance.WriteError("User clan is " + u.ClanId.ToString() + " but the server failed to load the clan");
                    Fill(4, -1);
                }

            }
            // CLAN BLOCKS
                Append2(0);
                Append2((byte)u.Premium);    // Premium Type.
                Append2(0);                  // Unknown.
                Append2(-1);                  // Unknown.
                Append2(0);
                Append2(Core.LevelCalculator.GetLevelforExp(u.XP)); // User Level (based on XP).
                Append2(u.XP);               // User XP.
                Append2(0);                  // Unknown. CASH?
                Append2(0);                  // Unknown.
                Append2(u.Money);            // User Money
                Append2(u.Kills);            // User Kills
                Append2(u.Deaths);           // User Deaths
                Fill(5, 0);                 // 5 Unknown blocks
            // SLOT STATE //
                Append2(u.Inventory.SlotState); // T = Slot Enabled, F = Slot disabled.
            // EQUIPMENT //
                Append2(u.Inventory.Equipment.ListsInternal[(byte)Classes.Engineer]);    // Equipment - Engeneer
                Append2(u.Inventory.Equipment.ListsInternal[(byte)Classes.Medic]);       // Equipment - Medic
                Append2(u.Inventory.Equipment.ListsInternal[(byte)Classes.Sniper]);      // Equipment - Sniper
                Append2(u.Inventory.Equipment.ListsInternal[(byte)Classes.Assault]);     // Equipment - Assault
                Append2(u.Inventory.Equipment.ListsInternal[(byte)Classes.Heavy]);       // Equipment - Heavy
            // INVENTORY //
                Append2(u.Inventory.Itemlist);

            //COSTUMES //
            Append2("BA01,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^");
            Append2("BA02,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^");
            Append2("BA03,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^");
            Append2("BA04,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^");
            Append2("BA05,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^,^");
            // END INVENTORY //
            for (int I = 0; I < 30; I++)
            {
               Append2("^,");
            }
            //Fill(2, 0); // Two unknown blocks.
            Append2("WARROCK");
            Append2(1);
            Append2(0);
            Append2("Spain");
        }
    }
}
