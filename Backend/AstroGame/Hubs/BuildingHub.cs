using AspNetCore.ServiceRegistration.Dynamic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Hubs
{
    [Authorize]
    [SingletonService]
    public class BuildingHub : Hub
    {
        public const string TechnologyUpgradeStartedKey =
            "TechnologyUpgradeStarted";
        public const string TechnologyUpgradeFinishedKey =
            "TechnologyUpgradeFinished";

        public override Task OnConnectedAsync()
        {
            var playerId = HubHelper.GetPlayerId(Context);

            return Groups.AddToGroupAsync(Context.ConnectionId, playerId.ToString());
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var playerId = HubHelper.GetPlayerId(Context);

            return Groups.RemoveFromGroupAsync(Context.ConnectionId, playerId.ToString());
        }
    }
}