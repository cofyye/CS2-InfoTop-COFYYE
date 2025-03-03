using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Translations;
using InfoTop_COFYYE.Variables;
using System.Drawing;

namespace InfoTop_COFYYE.Utils
{
    public static class HudUtils
    {
        public static InfoTopCOFYYE Instance => InfoTopCOFYYE.Instance;
        private static Dictionary<string, string> _currentHudMessage = [];

        public static void ShowHudAd()
        {
            var players = Utilities.GetPlayers().Where(p => PlayerUtils.IsValidPlayer(p));

            if (GlobalVariables.DurationHudTimer == 0)
            {
                _currentHudMessage = GlobalVariables.HudMessageProvider?.GetHudMessage() ?? [];
            }

            foreach (var player in players)
            {
                if (!GlobalVariables.IsActiveHud.ContainsKey(player.SteamID.ToString())) continue;
                if (GlobalVariables.IsActiveHud[player.SteamID.ToString()] is true) continue;


                string lang = player.GetLanguage().TwoLetterISOLanguageName ?? "en";
                string hudMessage = _currentHudMessage.TryGetValue(lang, out var msg) ? msg : _currentHudMessage["en"];
                var fontRGB = Instance?.Config?.HudRGBColor?.Split(",");

                GlobalVariables.GameHudApi?.Native_GameHUD_SetParams(player, 0, 
                                                        new CounterStrikeSharp.API.Modules.Utils.Vector(Instance?.Config?.HudPositionX ?? 0.0f, Instance?.Config?.HudPositionY ?? 40.0f, 80),
                                                        Color.FromArgb(int.Parse(fontRGB?[0] ?? "255"), int.Parse(fontRGB?[1] ?? "165"), int.Parse(fontRGB?[2] ?? "0")),
                                                        Instance?.Config?.HudFontSize ?? 16, Instance?.Config.HudFontFamily ?? "Arial Bold", 
                                                        Instance?.Config?.HudFontUnits ?? 0.25f,
                                                        PointWorldTextJustifyHorizontal_t.POINT_WORLD_TEXT_JUSTIFY_HORIZONTAL_CENTER,
                                                        PointWorldTextJustifyVertical_t.POINT_WORLD_TEXT_JUSTIFY_VERTICAL_TOP,
                                                        PointWorldTextReorientMode_t.POINT_WORLD_TEXT_REORIENT_NONE,
                                                        bgborderheight: Instance?.Config?.HudBgBorderHeight ?? 0.5f, 
                                                        bgborderwidth: Instance?.Config?.HudBgBorderWidth ?? 0.5f);
                GlobalVariables.GameHudApi?.Native_GameHUD_ShowPermanent(player, 0, hudMessage);

                GlobalVariables.IsActiveHud[player.SteamID.ToString()] = true;
            }
        }

        public static void ResetHud()
        {
            var players = Utilities.GetPlayers().Where(p => PlayerUtils.IsValidPlayer(p));

            foreach (var player in players)
            {
                if (!GlobalVariables.IsActiveHud.ContainsKey(player.SteamID.ToString())) continue;
                if (GlobalVariables.IsActiveHud[player.SteamID.ToString()] is false) continue;

                KillHud(player);
            }
        }

        public static void KillHud(CCSPlayerController player)
        {
            if(player == null) return;
            if (!GlobalVariables.IsActiveHud.ContainsKey(player.SteamID.ToString())) return;
            if (GlobalVariables.IsActiveHud[player.SteamID.ToString()] is false) return;

            GlobalVariables.GameHudApi?.Native_GameHUD_Remove(player, 0);
            GlobalVariables.IsActiveHud[player.SteamID.ToString()] = false;
        }
    }
}
