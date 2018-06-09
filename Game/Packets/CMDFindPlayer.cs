namespace Game.Packets
{
    class CMDFindPlayer : Core.Networking.OutPacket
    {
        public CMDFindPlayer(Entities.User Target)
            :base((ushort)Enums.Packets.CMDFindPlayer)
        {
            if (Target == null)
                Append2(0);
            else
            {
                Append2(1);
                Append2(Target.ID);
                Append2(Target.RemoteEndPoint.ToString());
                Append2((byte)Target.Premium);
                Append2(Target.XP);
                Append2(Target.Money);
                Append2(Target.Kills);
                Append2(Target.Deaths);
                Append2(Target.Deaths);
                if (Target.Room != null)
                {
                    Append2(Target.Room.ID);
                    Append2(Target.Room.Name);
                    Append2(Target.Room.Password);
                }
                else
                {
                    Fill(2, -1);
                }

                Append2(Target.SessionID);
            }
          
        }
    }
}
