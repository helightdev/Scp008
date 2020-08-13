using System;
using System.Globalization;
using Synapse.Api;
using Synapse.Api.Enums;
using UnityEngine;

namespace Scp008
{
    public class Scp008PlayerScript : MonoBehaviour
    {
        public bool isInfected = false;
        public int duration = Configs.InfectionDuration;

        private Player Player => this.GetPlayer();

        public void UpdateProgression()
        {
            duration--;
            if (duration == -1)
            {
                Convert(Player.Position);
                return;
            }
            Player.Broadcast(1,string.Format(Configs.Translation.GetTranslation("infected"), duration.ToString(CultureInfo.CurrentCulture)));
        }

        public void Convert(Vector3 position)
        {
            if (Player.Team == Team.SCP) return;
            Player.Role = RoleType.Scp0492;
            Player.Position = position;
            Player.Broadcast(5, Configs.Translation.GetTranslation("death"));
            ResetInfection();
        }

        public void Infect(Player source)
        {
            if (isInfected) return;
            isInfected = true;
            Player.Broadcast(1, string.Format(Configs.Translation.GetTranslation("infected"), duration.ToString(CultureInfo.CurrentCulture)));
        }

        public void Cure()
        { 
            Player.Broadcast(5, Configs.Translation.GetTranslation("cured")); 
            ResetInfection(); 
        }

        public void ResetInfection()
        {
            isInfected = false;
            duration = Configs.InfectionDuration;
        }
        
    }
}