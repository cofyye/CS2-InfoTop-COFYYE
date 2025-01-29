using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Translations;
using CounterStrikeSharp.API.Modules.Cvars;
using CounterStrikeSharp.API.Modules.Utils;

namespace InfoTop_COFYYE
{
    public class InfoTopCOFYYE : BasePlugin
    {
        public override string ModuleName => "InfoTop";
        public override string ModuleVersion => "1.0";
        public override string ModuleAuthor => "cofyye";
        public override string ModuleDescription => "https://github.com/cofyye";

        public override void Load(bool hotReload)
        {
            // Events
            RegisterEventHandler<EventRoundStart>(RoundStartHandler);
        }

        public override void Unload(bool hotReload)
        {
            // Unregister Events
            DeregisterEventHandler<EventRoundStart>(RoundStartHandler);
        }

        public HookResult RoundStartHandler(EventRoundStart @event, GameEventInfo info)
        {
            if (@event == null) return HookResult.Continue;

            var hostname = ConVar.Find("hostname")?.StringValue;
            var maxRounds = ConVar.Find("mp_maxrounds")?.GetPrimitiveValue<int>();
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

            var players = Utilities.GetPlayers().Where(p => p.IsValid && !p.IsBot && !p.IsHLTV && p.Connected == PlayerConnectedState.PlayerConnected).ToList();
            
            foreach ( var player in players )
            {
                var localizerWelcome = Localizer.ForPlayer(player, "infotop.welcome")
                                                .Replace("{HOSTNAME}", hostname);
                var localizerAddIP = Localizer.ForPlayer(player, "infotop.addip");
                var localizerText = Localizer.ForPlayer(player, "infotop.text")
                                                .Replace("{CURRENT_ROUNDS}", (ttScore + ctScore).ToString())
                                                .Replace("{MAX_ROUNDS}", maxRounds.ToString())
                                                .Replace("{CURRENT_MAP}", Server.MapName)
                                                .Replace("{CURRENT_PLAYERS}", Utilities.GetPlayers().Count.ToString())
                                                .Replace("{MAX_PLAYERS}", Server.MaxPlayers.ToString());

                player.PrintToChat(StringExtensions.ReplaceColorTags(localizerWelcome));
                player.PrintToChat(StringExtensions.ReplaceColorTags(localizerAddIP));
                player.PrintToChat(StringExtensions.ReplaceColorTags(localizerText));
            }

            return HookResult.Continue;
        }
    }
}
