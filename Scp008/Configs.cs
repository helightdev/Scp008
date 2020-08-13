using System.Collections.Generic;
using Synapse;
using Synapse.Api;
using Synapse.Api.Plugin;

namespace Scp008
{
    public class Configs
    {

        internal static Translation Translation;

        internal static int InfectionDuration;
        internal static float InfectionChance;
        internal static bool InfectOnKill;

        internal static void ReloadConfigs()
        {
            InfectionDuration = Plugin.Config.GetInt("infection_duration", 15);
            InfectionChance = Plugin.Config.GetFloat("infection_change", 0.33f);
            InfectOnKill = Plugin.Config.GetBool("infect_on_kill", true);
       
            var translation = new Dictionary<string,string>
            {
                {"infected", "You have been infected by SCP-008.\nYou will become a instance SCP-049-2 in {0} seconds,\nif you don't use a medicine"},
                {"cured", "You have been cured from SCP-008"},
                {"death", "The SCP-008 infection took over your body"}
            };

            Translation.CreateTranslations(translation);
        }

    }
}