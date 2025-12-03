using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Capabilities;
using CounterStrikeSharp.API.Core.Translations;
using CounterStrikeSharp.API.Modules.Cvars;
using CounterStrikeSharp.API.Modules.Extensions;
using CounterStrikeSharp.API.Modules.Timers;
using CounterStrikeSharp.API.Modules.Utils;
using CS2_GameHUDAPI;
using InfoTop_COFYYE.Utils;
using InfoTop_COFYYE.Variables;
using Microsoft.Extensions.Logging;

namespace InfoTop_COFYYE
{
    public class InfoTopCOFYYE : BasePlugin, IPluginConfig<Config.Config>
    {
        public override string ModuleName => "InfoTop";
        public override string ModuleVersion => "1.3";
        public override string ModuleAuthor => "cofyye";
        public override string ModuleDescription => "https://github.com/cofyye";

        public static InfoTopCOFYYE Instance { get; set; } = new();
        public Config.Config Config { get; set; } = new();

        public void OnConfigParsed(Config.Config config)
        {
            Config = config ?? throw new ArgumentNullException(nameof(config));

            Instance = this;
        }

        public override void Load(bool hotReload)
        {
            base.Load(hotReload);

            if (hotReload)
            {
                Config?.Reload();
            }

            GlobalVariables.WelcomeMessageProvider = new();
            GlobalVariables.AddIpProvider = new();
            GlobalVariables.InfoTopTextProvider = new();
            GlobalVariables.HudMessageProvider = new();

            if (Config?.EnableHudAds == true)
            {
                AddTimer(
                    1.0f,
                    () =>
                    {
                        if (GlobalVariables.DurationHudTimer < Config?.DurationPerHudAd)
                        {
                            // We show HUD advertisement until DurationHudTimer is limit (120)
                            HudUtils.ShowHudAd();
                            GlobalVariables.DurationHudTimer++;
                        }
                        else if (GlobalVariables.CooldownHudTimer < Config?.CoolDownPerHudAd)
                        {
                            // When DurationHudTimer expires, we start CooldownHudTimer(counts to 60)
                            HudUtils.ResetHud();
                            GlobalVariables.CooldownHudTimer++;
                        }
                        else
                        {
                            // When the CooldownHudTimer also expires, we reset both and start over
                            GlobalVariables.DurationHudTimer = 0;
                            GlobalVariables.CooldownHudTimer = 0;
                        }
                    },
                    TimerFlags.REPEAT
                );
            }

            // Events
            RegisterEventHandler<EventRoundStart>(RoundStartHandler);
            RegisterEventHandler<EventPlayerConnectFull>(PlayerConnectFullHandler);
            RegisterEventHandler<EventPlayerDisconnect>(PlayerDisconnectHandler);

            // Listeners
            RegisterListener<Listeners.OnMapStart>(OnMapStart);
        }

        public override void OnAllPluginsLoaded(bool hotReload)
        {
            try
            {
                PluginCapability<IGameHUDAPI> CapabilityCP = new("gamehud:api");
                GlobalVariables.GameHudApi = IGameHUDAPI.Capability.Get();
            }
            catch (Exception)
            {
                GlobalVariables.GameHudApi = null;
                Logger.LogError($"GameHUD API Loading Failed!");
            }
        }

        public override void Unload(bool hotReload)
        {
            GlobalVariables.WelcomeMessageProvider = null;
            GlobalVariables.AddIpProvider = null;
            GlobalVariables.InfoTopTextProvider = null;
            GlobalVariables.HudMessageProvider = null;

            // Unregister Events
            DeregisterEventHandler<EventRoundStart>(RoundStartHandler);
            DeregisterEventHandler<EventPlayerConnectFull>(PlayerConnectFullHandler);
            DeregisterEventHandler<EventPlayerDisconnect>(PlayerDisconnectHandler);

            // Unregister Listeners
            RemoveListener<Listeners.OnMapStart>(OnMapStart);
        }

        public HookResult PlayerConnectFullHandler(
            EventPlayerConnectFull @event,
            GameEventInfo info
        )
        {
            if (@event == null)
                return HookResult.Continue;

            var steamId = @event?.Userid?.SteamID.ToString();

            if (string.IsNullOrEmpty(steamId))
                return HookResult.Continue;

            GlobalVariables.IsActiveHud.Add(steamId, false);

            return HookResult.Continue;
        }

        public HookResult PlayerDisconnectHandler(EventPlayerDisconnect @event, GameEventInfo info)
        {
            if (@event == null)
                return HookResult.Continue;

            var steamId = @event?.Userid?.SteamID.ToString();

            if (string.IsNullOrEmpty(steamId))
                return HookResult.Continue;

            HudUtils.KillHud(@event?.Userid!);
            GlobalVariables.IsActiveHud.Remove(steamId);

            return HookResult.Continue;
        }

        public HookResult RoundStartHandler(EventRoundStart @event, GameEventInfo info)
        {
            if (@event == null)
                return HookResult.Continue;

            HudUtils.ResetHud();

            if (ServerUtils.GetGameRules().TotalRoundsPlayed % Config?.ShowInfoEveryXRound != 0)
            {
                return HookResult.Continue;
            }

            var prefix = Config?.Prefix ?? "{lightpurple}[InfoTop] {orange}»» ";
            var players = Utilities.GetPlayers().Where(p => PlayerUtils.IsValidPlayer(p)).ToList();

            foreach (var player in players)
            {
                if (Config?.EnableWelcomeMsg == true)
                {
                    var message =
                        GlobalVariables.WelcomeMessageProvider?.GetWelcomeMessage(
                            player.GetLanguage().TwoLetterISOLanguageName ?? "en"
                        ) ?? "Message not available";

                    var processedMessage = MessageUtils.ReplaceMessageParameters(message, player);
                    var lines = processedMessage.Split(["{NEXTLINE}"], StringSplitOptions.None);

                    foreach (var line in lines)
                    {
                        var fullText = prefix + line;
                        player.PrintToChat(StringExtensions.ReplaceColorTags(fullText));
                    }
                }

                if (Config?.EnableAddIpMsg == true)
                {
                    var message =
                        GlobalVariables.AddIpProvider?.GetAddIpMessage(
                            player.GetLanguage().TwoLetterISOLanguageName ?? "en"
                        ) ?? "Message not available";

                    var processedMessage = MessageUtils.ReplaceMessageParameters(message, player);
                    var lines = processedMessage.Split(["{NEXTLINE}"], StringSplitOptions.None);

                    foreach (var line in lines)
                    {
                        var fullText = prefix + line;
                        player.PrintToChat(StringExtensions.ReplaceColorTags(fullText));
                    }
                }

                if (Config?.EnableInfoTopText == true)
                {
                    var message =
                        GlobalVariables.InfoTopTextProvider?.GetInfoTopTextMessage(
                            player.GetLanguage().TwoLetterISOLanguageName ?? "en"
                        ) ?? "Message not available";

                    var processedMessage = MessageUtils.ReplaceMessageParameters(message, player);
                    var lines = processedMessage.Split(["{NEXTLINE}"], StringSplitOptions.None);

                    foreach (var line in lines)
                    {
                        var fullText = prefix + line;
                        player.PrintToChat(StringExtensions.ReplaceColorTags(fullText));
                    }
                }
            }

            return HookResult.Continue;
        }

        public void OnMapStart(string mapName)
        {
            Config?.Reload();
        }
    }
}
