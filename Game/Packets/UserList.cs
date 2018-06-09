/* SHARED BY CODEDRAGON. DO NOT SHARE THIS */

using Game.Enums;
using System.Collections;

namespace Game.Packets
{
    class UserList : Core.Networking.OutPacket
    {

        public UserList(int _intPage, ArrayList _userList)
            : base(28928)
        {

            Append2(_userList.Count);
            Append2(_intPage);

            for (int i = 0; i < _userList.Count; i++)
            {
                Entities.User u = (Entities.User)_userList[i];
                Append2(i + _intPage * 10); // List Index
                Append2(u.ID); // UID
                Append2(u.SessionID); // Session ID
                Append2(u.Displayname); // Nickname

                Objects.Clan Clan = Managers.ClanManager.Instance.GetClan(u.ClanId);

                if (Clan == null)
                    Fill(4, -1);
                else
                {
                    Append2(u.ClanId);
                    Append2(Clan.Name);
                    Append2(u.ClanRank);
                    Append2(((u.ClanId > 0) ? 0 : -1)); // Unknown?
                }

                Append2(0); // Unknown
                Append2(16); // Unknown
                Append2(u.XP);
                Append2((byte)u.Premium);
                Append2(0);

            }

        }
    }
}