using System;
using CommandSystem;
using Synapse.Api;

namespace Scp008
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class InfectCommand : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count != 1)
            {
                response = "infect <int:PlayerID>";
                return false;
            }

            if (!sender.CheckPermission(PlayerPermissions.ForceclassWithoutRestrictions))
            {
                response = "You must have the permission 'ForceclassWithoutRestrictions' to do this";
                return false;
            }
            
            var player = Player.GetPlayer(int.Parse(arguments.At(0)));
            player.getScp008().Infect(sender.GetPlayer());
            response = "Player has been infected";
            return true;
        }

        public string Command { get; } = "infect";
        public string[] Aliases { get; } = {"inf"};
        public string Description { get; } = "Infects a player with SCP-008";
    }

}