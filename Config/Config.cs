using CounterStrikeSharp.API.Core;
using System.Text.Json.Serialization;

namespace InfoTop_COFYYE.Config
{
    public class Config : BasePluginConfig
    {
        [JsonPropertyName("enable_welcome_msg")]
        public bool EnableWelcomeMsg { get; init; } = true;

        [JsonPropertyName("enable_addip_msg")]
        public bool EnableAddIpMsg { get; init; } = true;

        [JsonPropertyName("enable_infotop_text")]
        public bool EnableInfoTopText { get; init; } = true;

        [JsonPropertyName("show_info_every_x_round")]
        public int ShowInfoEveryXRound { get; init; } = 1;

        [JsonPropertyName("enable_hud_ads")]
        public bool EnableHudAds { get; init; } = true;

        [JsonPropertyName("duration_per_hud_ad")]
        public int DurationPerHudAd { get; init; } = 120;

        [JsonPropertyName("cooldown_per_hud_ad")]
        public int CoolDownPerHudAd { get; init; } = 60;

        [JsonPropertyName("hud_rgb_color")]
        public string HudRGBColor { get; init; } = "255,165,0";

        [JsonPropertyName("hud_font_size")]
        public int HudFontSize { get; init; } = 35;

        [JsonPropertyName("hud_font_family")]
        public string HudFontFamily { get; init; } = "Arial Bold";

        [JsonPropertyName("hud_position_x")]
        public float HudPositionX { get; init; } = -2.4f;

        [JsonPropertyName("hud_position_y")]
        public float HudPositionY { get; init; } = 3.8f;

        [JsonPropertyName("enable_hud_background")]
        public bool EnableHudBackground { get; init; } = true;

        [JsonPropertyName("welcome_messages")]
        public Dictionary<string, Dictionary<string, string>> WelcomeMessages { get; init; } = new()
        {
            ["welcome_message_1"] = new()
            {
                ["sr"] = "{lightpurple}[Info] {orange}★彡 {yellow}Dobrodosli na{orange}【 {lime}{HOSTNAME}{orange} 】彡★",
                ["en"] = "{lightpurple}[Info] {orange}★彡 {yellow}Welcome to{orange}【 {lime}{HOSTNAME}{orange} 】彡★"
            }
        };

        [JsonPropertyName("addip_messages")]
        public Dictionary<string, Dictionary<string, string>> AddIpMessages { get; init; } = new()
        {
            ["addip_message_1"] = new()
            {
                ["sr"] = "{lightpurple}[Info] {yellow}Dodajte IP u favorites {orange}➤➤ {lime}127.0.0.1:27015",
                ["en"] = "{lightpurple}[Info] {yellow}Add IP to favorites {orange}➤➤ {lime}127.0.0.1:27015"
            }
        };

        [JsonPropertyName("infotop_text_messages")]
        public Dictionary<string, Dictionary<string, string>> InfoTopTextMessages { get; init; } = new()
        {
            ["infotop_text_message_1"] = new()
            {
                ["sr"] = "{lightpurple}[Info] {yellow}Runda: {lime}{CURRENT_ROUNDS}{yellow}/{lime}{MAX_ROUNDS} {orange}• {yellow}Mapa: {lime}{CURRENT_MAP} {orange}• {yellow}Igraci: {lime}{CURRENT_PLAYERS}{yellow}/{lime}{MAX_PLAYERS}",
                ["en"] = "{lightpurple}[Info] {yellow}Round: {lime}{CURRENT_ROUNDS}{yellow}/{lime}{MAX_ROUNDS} {orange}• {yellow}Map: {lime}{CURRENT_MAP} {orange}• {yellow}Players: {lime}{CURRENT_PLAYERS}{yellow}/{lime}{MAX_PLAYERS}"
            }
        };

        [JsonPropertyName("hud_messages")]
        public Dictionary<string, Dictionary<string, string>> HudMessages { get; init; } = new()
        {
            ["hud_message_1"] = new()
            {
                ["sr"] = "Dodajte IP u favorites ➤➤ 127.0.0.1:27015",
                ["en"] = "Add IP to favorites ➤➤ 127.0.0.1:27015"
            },
            ["hud_message_2"] = new()
            {
                ["sr"] = "Pridruzite se nasem Discord serveru, kucaj !discord",
                ["en"] = "Join our Discord server, say !discord"
            },
        };
    }
}
