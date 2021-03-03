using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Api.Hubs
{
    public class GameHub : Hub
    {
        private static List<string> _players = new List<string>();

        public override Task OnConnectedAsync()
        {
            _players.Add(Context.ConnectionId);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _players.Remove(Context.ConnectionId);

            return base.OnDisconnectedAsync(exception);
        }
    }
}