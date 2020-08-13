using System.Collections.Generic;
using MEC;
using Synapse;
using Synapse.Api;

namespace Scp008
{
    public class Coroutines
    {
        
        private List<CoroutineHandle> _handles = new List<CoroutineHandle>();

        internal void Start()
        {
            Log.Info(":: Starting Scp008 Coroutines ::");
            _handles.Add(Timing.RunCoroutine(InfectionProgressRoutine()));
        }

        internal void Stop()
        {
            Log.Info(":: Stopping Scp008 Coroutines ::");
            Timing.KillCoroutines(_handles);
            _handles.Clear();
        }

        private IEnumerator<float> InfectionProgressRoutine()
        {
            Log.Info("Started InfectionProgressCoroutine");
            
            for (;;)
            {
                foreach (var player in Player.GetAllPlayers())
                {
                    var script = player.getScp008();
                    if (script.isInfected) script.UpdateProgression();
                }

                yield return Timing.WaitForSeconds(1f);
            }

        }
        
    }
}