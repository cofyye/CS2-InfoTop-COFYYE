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
                if (!GlobalVariables.HudText.ContainsKey(player.SteamID.ToString())) continue;
                if (GlobalVariables.HudText[player.SteamID.ToString()] != null) continue;

                PlayerUtils.InitializePlayerWorldText(player);

                string lang = player.GetLanguage().TwoLetterISOLanguageName ?? "en";
                string hudMessage = _currentHudMessage.TryGetValue(lang, out var msg) ? msg : _currentHudMessage["en"];

                var hudText = GlobalVariables.HudText[player.SteamID.ToString()];

                Instance?.AddTimer(0.1f, () =>
                {
                    var fontRGB = Instance?.Config?.HudRGBColor?.Split(",");

                    hudText = WorldTextManager.Create(
                        player, hudMessage, Instance?.Config?.HudFontSize ?? 35,
                        Color.FromArgb(int.Parse(fontRGB?[0] ?? "255"), int.Parse(fontRGB?[1] ?? "165"), int.Parse(fontRGB?[2] ?? "0")), 
                        Instance?.Config.HudFontFamily ?? "Arial Bold",
                        Instance?.Config?.HudPositionX ?? -2.4f, Instance?.Config?.HudPositionY ?? 3.8f,
                        Instance?.Config?.EnableHudBackground == true, 0.1f, 0.1f);

                    if (hudText != null && hudText.IsValid)
                    {
                        hudText.AcceptInput("SetMessage", hudText, hudText, hudMessage);
                    }

                    GlobalVariables.HudText[player.SteamID.ToString()] = hudText;
                });
            }
        }

        public static void ResetHud()
        {
            var players = Utilities.GetPlayers().Where(p => PlayerUtils.IsValidPlayer(p));

            foreach (var player in players)
            {
                if (!GlobalVariables.HudText.ContainsKey(player.SteamID.ToString())) continue;
                if (GlobalVariables.HudText[player.SteamID.ToString()] == null) continue;

                KillHud(player);
                GlobalVariables.HudText[player.SteamID.ToString()] = null;
            }
        }

        public static void KillHud(CCSPlayerController player)
        {
            if(player == null) return;
            if (!GlobalVariables.HudText.ContainsKey(player.SteamID.ToString())) return;
            if (GlobalVariables.HudText[player.SteamID.ToString()] == null) return;

            var hudText = GlobalVariables.HudText[player.SteamID.ToString()];

            if (hudText != null && hudText.IsValid)
            {
                hudText.Enabled = false;
                hudText.AcceptInput("Kill", hudText);
                WorldTextManager.WorldTextOwners.Clear();

                GlobalVariables.HudText[player.SteamID.ToString()] = null;
            }
        }
    }
}
