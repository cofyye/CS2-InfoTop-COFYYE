using CS2_GameHUDAPI;
using InfoTop_COFYYE.Providers;

namespace InfoTop_COFYYE.Variables
{
    public static class GlobalVariables
    {
        public static Dictionary<string, bool?> IsActiveHud { get; } = [];
        public static WelcomeMessageProvider? WelcomeMessageProvider { get; set; } = null;
        public static AddIpProvider? AddIpProvider { get; set; } = null;
        public static InfoTopTextProvider? InfoTopTextProvider { get; set; } = null;
        public static HudMessageProvider? HudMessageProvider { get; set; } = null;
        private static IGameHUDAPI? _gameHudApi = null;
        public static int DurationHudTimer { get; set; } = 0;
        public static int CooldownHudTimer { get; set; } = 0;

        public static IGameHUDAPI? GameHudApi { get { return _gameHudApi; } set { _gameHudApi = value; } }
    }
}
