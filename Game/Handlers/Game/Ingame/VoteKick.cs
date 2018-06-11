namespace Game.Handlers.Game.Ingame
{
    class VoteKick : Networking.GameDataHandler
    {
        protected override void Handle()
        {
            if (Room.State == Enums.RoomState.Playing && Room.Mode !=  Enums.Mode.Free_For_All) //cannot kick in FFA
            {

                Entities.Player pKicker = null;
                Entities.Player pVictim = null;

                byte newVoteKick    = GetByte(2); // 0 = no votekick 1  = kicking already... SET it to 1 to launch a votekick
                byte kickVictim     = GetByte(3);
                byte kicker         = GetByte(6);

                //check for a valid kicker
                try
                {
                    Room.Players.TryGetValue(kicker, out pKicker);
                    Room.Players.TryGetValue(kickVictim, out pVictim);
                }
                catch
                {
                    //Player.User.Disconnect(); smth fishy going on here
                }
                    
                if(pKicker.Team == pVictim.Team)
                {
                    //A supermaster cannot be kicked off rooms he makes
                    if (Room.Master == kickVictim && Room.Supermaster && pVictim.User.Inventory.Get("CC02") != null)
                        return;
                    
                    if(!Room.VoteKickStarted)
                    {               
                        Set(2, 1); //new votekick

                        Room.VoteKickCandidate = kickVictim;
                        Room.VoteKickStarted   = true;
                        respond = true;
                    }
                    else //there is one votekick running already... respond only to YES/NO packets
                    {
                       
                    }
                }
            
              
            }
        }
    }
}
