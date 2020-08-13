using System;
using MEC;
using Synapse;
using Synapse.Events;
using Synapse.Events.Classes;

namespace Scp008
{
    public class EventHandlers
    {
        private Scp008 _plugin;

        private Random _random = new Random();
        
        public EventHandlers(Scp008 plugin)
        {
            this._plugin = plugin;

            Events.LoadComponentsEvent += OnLoadComponents;
            Events.RoundStartEvent += OnRoundStart;
            Events.RoundEndEvent += OnRoundEnd;
            Events.PlayerDeathEvent += OnDeath;
            Events.PlayerHurtEvent += OnHurt;
            Events.PlayerHealEvent += OnPlayerHeal;
        }

        private void OnRoundStart()
        {
            _plugin.Coroutines.Start();
        }

        private void OnRoundEnd()
        {
            Scp008.ResetAll();
            _plugin.Coroutines.Stop();
        }

        private void OnDeath(PlayerDeathEvent ev)
        {
            var player = ev.Player;
            if (player.getScp008().isInfected || (Configs.InfectOnKill && ev.Killer != null &&  ev.Killer.Role == RoleType.Scp0492 && ev.Killer.PlayerId != player.PlayerId))
            {
                Timing.CallDelayed(1f, () => player.getScp008().Convert(player.Position));
            }
        }

        public void OnPlayerHeal(PlayerHealEvent ev)
        {
            var player = ev.Player;
            if (ev.Player.getScp008().isInfected)
            {
                player.getScp008().Cure();
            }
        }

        public void OnHurt(PlayerHurtEvent ev)
        {
            if (ev.Attacker == null) return;
            
            if (ev.Attacker.Role == RoleType.Scp0492 && ev.Info.GetDamageType() == DamageTypes.Scp0492)
            {
                if (_random.NextDouble() <= Configs.InfectionChance)
                    ev.Player.getScp008().Infect(ev.Attacker);
            }
        }
        
        public void OnLoadComponents(LoadComponentsEvent ev)
        {
            if (ev.Player.GetComponent<Scp008PlayerScript>() == null)
                ev.Player.AddComponent<Scp008PlayerScript>();
        }
    }
}