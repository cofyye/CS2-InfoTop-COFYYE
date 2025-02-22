using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API;

namespace InfoTop_COFYYE.Utils
{
    public static class ServerUtils
    {
        public static CCSGameRules GetGameRules()
        {
            var gameRulesEntities = Utilities.FindAllEntitiesByDesignerName<CCSGameRulesProxy>("cs_gamerules");
            var gameRules = gameRulesEntities.First().GameRules;

            if (gameRules == null)
            {
                throw new ArgumentNullException(nameof(gameRules));
            }

            return gameRules;
        }
    }
}
