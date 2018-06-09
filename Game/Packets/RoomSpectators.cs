using System;
using System.Collections;

namespace Game.Packets
{
     class RoomSpectators : Core.Networking.OutPacket
     {
         public RoomSpectators(ArrayList Spectators)
             : base((ushort)Enums.Packets.SpectatorInfo)    
       {
           foreach (Entities.User User in Spectators)
           {
               Append2(1);
               Append2(0);
               Append2(User.SpectatorId);
               Append2(User.ID);
               Append2(User.SessionID);
               Append2(User.Displayname);
               Append2("0");
               Append2(999);
               Append2(User.RemoteEndPoint.Address.Address);
               Append2(User.RemotePort);
               Append2(User.LocalEndPoint.Address.Address);
               Append2(User.LocalPort);
               Append2(0);
           }
         }

         public RoomSpectators(Entities.User Spectator) : base((ushort)Enums.Packets.SpectatorInfo)
         {
             Append2(1);
             Append2(0);
             Append2(Spectator.SpectatorId);
             Append2(Spectator.ID);
             Append2(Spectator.SessionID);
             Append2(Spectator.Displayname);
             Append2(999);

         }
   
    }
}