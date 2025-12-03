using CounterStrikeSharp.API.Core;

namespace InfoTop_COFYYE.Utils
{
    public static class PlayerUtils
    {
        public static bool IsValidPlayer(CCSPlayerController? p)
        {
            return p != null
                && p.IsValid
                && !p.IsBot
                && !p.IsHLTV
                && p.Connected == PlayerConnectedState.PlayerConnected;
        }

        public static string GetPlayerNickname(CCSPlayerController player)
        {
            if (
                !IsValidPlayer(player)
                || player.PlayerName == null
                || player.PlayerName.Length == 0
            )
            {
                return "Unknown";
            }

            return player.PlayerName;
        }
    }
}
