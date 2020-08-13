using Synapse.Api;

namespace Scp008
{
    public static class Extension
    {
        public static Scp008PlayerScript getScp008(this Player player) => player.GetComponent<Scp008PlayerScript>();
    }
}