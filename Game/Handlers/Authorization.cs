﻿using System;
using System.Collections;
namespace Game.Handlers {
    class Authorization : Networking.PacketHandler
    {
        protected override void Process(Entities.User u)
        {

            uint userId = GetuInt(0);
            string username = GetString(2);
            string displayname = GetString(3);
            uint sessionId = GetuInt(4); // Login session Id
            byte _accessLevel = GetByte(5);

                if (userId > 0 && username.Length > 2 && displayname.Length > 2 && sessionId > 0)
                {
                    if (Managers.UserManager.Instance.Add(sessionId, u))
                    {
                        Program.AuthServer.Send(new Packets.Internal.PlayerAuthorization(sessionId, userId, username, _accessLevel));
                    }
                    else
                    {
                        u.Send(new Packets.Authorization(Packets.Authorization.ErrorCodes.NormalProcedure));
                        u.Disconnect();
                    }
                }
                else
                {
                    u.Send(new Packets.Authorization(Packets.Authorization.ErrorCodes.NormalProcedure));
                    u.Disconnect();
                }
            }
        }
}

