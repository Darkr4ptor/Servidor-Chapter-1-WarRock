using System;
using Game.Enums;


  namespace Game.Packets {

      class VehicleExplode : Core.Networking.OutPacket
      {
          public VehicleExplode(Entities.Room r, Entities.Vehicle v)
              : base(30000)
          {
              Append2(1);
              Append2(-1); // Sender
              Append2(r.ID); // Room id
              Append2(2);
              Append2(153);
              Append2(0);
              Append2(1);
              Append2(0);
              Append2(v.MapID); // Target
              Append2(0);
              Append2(2);
              Append2(0);
              Append2(7);
              Append2(2);
              Append2(0);
              Append2(1);
              Append2(100);
              Append2(0);
              Append2(0);
              // Coords //
              Append2(0);
              Append2(0);
              Append2(0);
              // End Coords //
              Append2(0);
              Append2(0);
              Append2(0);
              Append2(0);
              Append2(0);
              Append2("FFFF");
          }

      }
}