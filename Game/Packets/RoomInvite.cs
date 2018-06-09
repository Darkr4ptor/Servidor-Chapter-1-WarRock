using System;


namespace Game.Packets
{
    class RoomInvite : Core.Networking.OutPacket
    {
        public RoomInvite(Enums.RoomInviteErrors _errorCode)
            : base((ushort)Enums.Packets.RoomInvite)
        {
            Append2((uint)_errorCode);
        }
        public RoomInvite(Entities.User User, string Message)
            : base((ushort)Enums.Packets.RoomInvite)
        {
            //29520 dark Let´s play a room together, come in!!!!

            Append2(1);
            Append2(0);
            Append2(-1);
            Append2(User.SessionID);
            Append2(User.SessionID); // Ping ?!
            Append2(User.Displayname);

            Objects.Clan UserClan = Managers.ClanManager.Instance.GetClan(User.ClanId);

            if (UserClan == null)
                Fill(4, -1);
            else
            {
                Append2(User.ClanId);
                Append2(UserClan.Tag);
                Append2(User.ClanRank);
                Append2(User.ClanRank);
            }

            Append2(1);
            Append2(18);
            Append2(User.XP);
            Append2(3);
            Append2(0);
            Append2(-1);
            Append2(Message);
            Append2(User.Room.ID);
            Append2(User.Room.Password);
        }
    }
}
