using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Translations;
using CounterStrikeSharp.API.Modules.Cvars;

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
                if (teamManager.TeamNum == 2) //t
                {
                    ttScore += teamManager.Score;
                }
                if (teamManager.TeamNum == 3) //ct
                {
                    ctScore += teamManager.Score;
                }
            }

            var localizerWelcome = Localizer["infotop.welcome"];
            var localizerAddIP = Localizer["infotop.addip"];
            var localizerText = Localizer["infotop.text"];

            var replacedWelcomeText = localizerWelcome.Value
                                                 .Replace("{HOSTNAME}", hostname);

            var replacedInfoText = localizerText.Value
                                                 .Replace("{CURRENT_ROUNDS}", (ttScore + ctScore).ToString())
                                                 .Replace("{MAX_ROUNDS}", maxRounds.ToString())
                                                 .Replace("{CURRENT_MAP}", Server.MapName)
                                                 .Replace("{CURRENT_PLAYERS}", Utilities.GetPlayers().Count.ToString())
                                                 .Replace("{MAX_PLAYERS}", Server.MaxPlayers.ToString());

            Server.PrintToChatAll(StringExtensions.ReplaceColorTags(replacedWelcomeText));
            Server.PrintToChatAll(StringExtensions.ReplaceColorTags(localizerAddIP));
            Server.PrintToChatAll(StringExtensions.ReplaceColorTags(replacedInfoText));

            return HookResult.Continue;
        }
    }
}
