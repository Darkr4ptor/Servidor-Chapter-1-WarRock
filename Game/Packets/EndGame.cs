using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Packets {
    class EndGame : Core.Networking.OutPacket {
        public EndGame(Entities.Room r, Entities.Player[] players, Enums.Team winningTeam)
            : base((ushort)Enums.Packets.EndGame) {

                int[] teamKills = new int[] { 0, 0 };
                int[] teamDeaths = new int[] { 0, 0 };

                teamKills[(byte)Enums.Team.Derbaran] = players.Where(n => n.Team == Enums.Team.Derbaran).Sum(n => n.Kills);
                teamKills[(byte)Enums.Team.NIU] = players.Where(n => n.Team == Enums.Team.NIU).Sum(n => n.Kills);
                teamDeaths[(byte)Enums.Team.Derbaran] = players.Where(n => n.Team == Enums.Team.Derbaran).Sum(n => n.Deaths);
                teamDeaths[(byte)Enums.Team.NIU] = players.Where(n => n.Team == Enums.Team.NIU).Sum(n => n.Deaths);

            Append2(Core.Constants.Error_OK);

            if (r.CurrentGameMode != null) //random crash
            {
                Append2(r.CurrentGameMode.CurrentRoundTeamA()); //DERBARAN ROUNDS
                Append2(r.CurrentGameMode.CurrentRoundTeamB()); //NIU ROUNDS
            }
            else
            {
                Fill(2, 0);
                Log.Instance.WriteDev("FFA Crash stopped"); //TODO
            }
                
       
            Append2(teamKills[(byte)Enums.Team.Derbaran]);
            Append2(teamDeaths[(byte)Enums.Team.Derbaran]);
            Append2(teamKills[(byte)Enums.Team.NIU]);
            Append2(teamDeaths[(byte)Enums.Team.NIU]);
            Append2(0);
            Append2(0);
            Append2(players.Length);
                for (byte i = 0; i < players.Length; i++) {
                    Entities.Player plr = players[i];
                    Append2(plr.Id); // Slot
                    Append2(plr.Kills); // Kills
                    Append2(plr.Deaths); // Deaths
                    Append2(plr.Flags); //Flags
                    Append2(plr.Points); // Points 
                    Append2(plr.MoneyEarned); // Dinar earned
                    Append2(plr.XPEarned); // Exp earned
                    Append2(plr.User.XP); // Player Exp
                }

                Append2(r.Master);
        }
    }
}
