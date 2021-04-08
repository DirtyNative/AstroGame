using AspNetCore.ServiceRegistration.Dynamic;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace AstroGame.Api.Hubs
{
    [Authorize]
    [SingletonService]
    public class BuildingHub : Hub<IBuildingHub>
    {
        private readonly IHubContext<BuildingHub> _context;

        public BuildingHub(IHubContext<BuildingHub> context)
        {
            _context = context;
        }

        public override Task OnConnectedAsync()
        {
            var playerId = HubHelper.GetPlayerId(Context);

            _context.Groups.AddToGroupAsync(Context.ConnectionId, playerId.ToString());

            return base.OnConnectedAsync();
        }

        public Task SendBuildingConstructionFinished(Guid playerId)
        {
            var group = _context.Clients.Group(playerId.ToString());
            return group.SendCoreAsync("BuildingConstructionFinished", null);
        }
    }

    public interface IBuildingHub
    {
    }
}