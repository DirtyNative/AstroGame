using AspNetCore.ServiceRegistration.Dynamic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace AstroGame.Api.Hubs
{
    [Authorize]
    [SingletonService]
    public class BuildingHub : Hub<IBuildingHub>
    {
       
    }

    public interface IBuildingHub
    {
        Task InformClient(string message);
    }
}