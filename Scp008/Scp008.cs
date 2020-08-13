using Synapse.Api;
using Synapse.Api.Plugin;

namespace Scp008
{
    [PluginDetails(
        Author = "Helight",
        Name = "Scp008",
        Description = "A ",
        Version = "1.0",
        SynapseMajor = 1,
        SynapseMinor = 1,
        SynapsePatch = 2
    )]
    public class Scp008 : Plugin
    {
        internal Coroutines Coroutines;
        
        public override void OnEnable()
        {
            Coroutines = new Coroutines();
            
            Configs.Translation = this.Translation;
            Configs.ReloadConfigs();
            ConfigReloadEvent += Configs.ReloadConfigs;
            
            new EventHandlers(this);
        }
        
        public static void ResetAll()
        {
            foreach (var player in Player.GetAllPlayers())
            {
                player.getScp008().ResetInfection();
            }
        }
    }
    
}