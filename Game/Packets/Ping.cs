using Game.Enums;

namespace Game.Packets
{
    class Ping : Core.Networking.OutPacket
    {

        public Ping(Entities.User u)
            : base((ushort)Enums.Packets.Ping)
        {
            Append2(5000); // Ping frequency
            Append2(u.Ping); // Ping
            Append2(0);  // -1 = no evento  175 = evento de navidad
            Append2(-1); // Duración del evento
            Append2(4); // 3 exp weekend, 4 exp event, 0 = none
            Append2(Game.GameConfig.ExpRate); // EXP Rate
            Append2(Game.GameConfig.DinarRate); // Dinar Rate
            Append2((u.PremiumTimeInSeconds > 0) ? u.PremiumTimeInSeconds : -1); // Premium Time
        }
    }
}
