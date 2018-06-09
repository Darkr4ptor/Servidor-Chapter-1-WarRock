using System;
using System.Collections;

namespace Game.Packets {
    class RoomPlayers : Core.Networking.OutPacket {
        public RoomPlayers(ArrayList arrPlayers)
            : base((ushort)Enums.Packets.PlayerInfo) {
                Append2(arrPlayers.Count);
                foreach (Entities.Player p in arrPlayers) {
                    Append2(p.User.ID);              // Player account id.
                    Append2(p.User.SessionID);       // Player session id.
                    Append2(p.Id);                   // The id of the room slot.
                    Append2(p.Ready);                // Indicates if the player is ready.
                    Append2((byte)p.Team);           // The team side of the player.
                    Append2(p.Weapon);               // The weapon that the player is currently wearing.
                    Append2(0);                      // Unknown?
                    Append2((byte)p.Class);          // The current class of the player.
                    Append2(p.Health);               // The current health of the player.
                    Append2(p.User.Displayname);     // The nickname of the player.
                    // CLAN INFORMATION
                    Objects.Clan Clan = Managers.ClanManager.Instance.GetClan(p.User.ClanId);

                    if (Clan == null)
                        Fill(3, -1);
                    else
                    {
                        Append2(p.User.ClanId);
                        Append2(Clan.Name);
                        Append2(p.User.ClanRank);
                    }
                    // END CLAN
                    Append2(1);                      // Unknown?
                    Append2(0);                      // Unknown?
                    Append2(910);                    // Unknown?
                    Append2((byte)p.User.Premium);   // The premium of the current player.
                    Append2(-1);                     // Unknown?
                    Append2(p.User.Kills);           // The total kills of the player.
                    Append2(p.User.Deaths);          // The total deaths of the player.
                    Append2(new Random().Next(150)); // Unknown?
                    Append2(p.User.XP);              // The current XP of the player | -1 = Special Badge
                    Append2(-1);                     // The id of the vehicle that the player is in. //DARKRAPTOR: CHECK THIS
                    Append2(-1);                     // The current slot of the vehicle that the player is in. //DARKRAPTOR: CHECK THIS
                    // CONNECTION INFORMATION //
                    Append2(p.User.RemoteEndPoint.Address.Address);  // The Remote endpoint ip as a long.
                    Append2(p.User.RemotePort);                      // The remote port.
                    Append2(p.User.LocalEndPoint.Address.Address);   // The Remote endpoint ip as a long.
                    Append2(p.User.LocalPort);                       // The remote port.
                    // END CONNECTION INFO //
                    Append2(0);                      // Unknown?
                }
        }
    }
}
