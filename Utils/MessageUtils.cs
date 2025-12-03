using System.Runtime.InteropServices;
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Cvars;
using CounterStrikeSharp.API.Modules.Utils;

namespace InfoTop_COFYYE.Utils
{
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate nint CNetworkSystemUpdatePublicIp(nint thisPtr);

    public static class MessageUtils
    {
        private static CNetworkSystemUpdatePublicIp? _networkSystemUpdatePublicIp;

        public static (int ttScore, int ctScore) GetTeamScores()
        {
            var ctScore = 0;
            var ttScore = 0;

            var teamManagers = Utilities.FindAllEntitiesByDesignerName<CCSTeam>("cs_team_manager");

            foreach (var teamManager in teamManagers)
            {
                if ((CsTeam)teamManager.TeamNum == CsTeam.Terrorist)
                {
                    ttScore += teamManager.Score;
                }
                if ((CsTeam)teamManager.TeamNum == CsTeam.CounterTerrorist)
                {
                    ctScore += teamManager.Score;
                }
            }

            return (ttScore, ctScore);
        }

        public static string GetServerIp()
        {
            var networkSystem = NativeAPI.GetValveInterface(0, "NetworkSystemVersion001");

            unsafe
            {
                if (_networkSystemUpdatePublicIp == null)
                {
                    var funcPtr = *(nint*)(*(nint*)networkSystem + 256);
                    _networkSystemUpdatePublicIp =
                        Marshal.GetDelegateForFunctionPointer<CNetworkSystemUpdatePublicIp>(
                            funcPtr
                        );
                }
                /*
                struct netadr_t
                {
                   uint32_t type
                   uint8_t ip[4]
                   uint16_t port
                }
                */
                // + 4 to skip type, because the size of uint32_t is 4 bytes
                var ipBytes = (byte*)(_networkSystemUpdatePublicIp(networkSystem) + 4);
                // port is always 0, use the one from convar "hostport"
                return $"{ipBytes[0]}.{ipBytes[1]}.{ipBytes[2]}.{ipBytes[3]}";
            }
        }

        public static string ReplaceMessageParameters(
            string message,
            CCSPlayerController? player = null
        )
        {
            var hostname = ConVar.Find("hostname")?.StringValue ?? "Unknown";
            var maxRounds = ConVar.Find("mp_maxrounds")?.GetPrimitiveValue<int>() ?? 0;
            var ip = GetServerIp();
            var port = ConVar.Find("hostport")?.GetPrimitiveValue<int>() ?? 27015;
            var serverIp = $"{ip}:{port}";
            var (ttScore, ctScore) = GetTeamScores();

            var result = message
                .Replace("{HOSTNAME}", hostname)
                .Replace("{IP}", serverIp)
                .Replace("{CURRENT_ROUNDS}", (ttScore + ctScore + 1).ToString())
                .Replace("{MAX_ROUNDS}", maxRounds.ToString())
                .Replace("{CURRENT_MAP}", Server.MapName)
                .Replace("{CURRENT_PLAYERS}", Utilities.GetPlayers().Count.ToString())
                .Replace("{MAX_PLAYERS}", Server.MaxPlayers.ToString());

            if (player != null)
            {
                result = result.Replace("{PLAYER_NAME}", PlayerUtils.GetPlayerNickname(player));
            }

            return result;
        }
    }
}
