using CounterStrikeSharp.API.Core;
using InfoTop_COFYYE.Providers;

namespace InfoTop_COFYYE.Variables
{
    public static class GlobalVariables
    {
        public static Dictionary<string, CPointWorldText?> HudText { get; } = [];
        public static WelcomeMessageProvider? WelcomeMessageProvider { get; set; } = null;
        public static AddIpProvider? AddIpProvider { get; set; } = null;
        public static InfoTopTextProvider? InfoTopTextProvider { get; set; } = null;
        public static HudMessageProvider? HudMessageProvider { get; set; } = null;
        public static int DurationHudTimer { get; set; } = 0;
        public static int CooldownHudTimer { get; set; } = 0;
    }
}
