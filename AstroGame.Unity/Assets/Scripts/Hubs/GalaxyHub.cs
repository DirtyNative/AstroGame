using System;
using Assets.Scripts.Communications;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using BestHTTP.SignalR.Hubs;

namespace Assets.Scripts.Hubs
{
    public class GalaxyHub : Hub
    {
        private readonly ConnectionService _connection;

        public GalaxyHub(ConnectionService connection) : base(nameof(GalaxyHub))
        {
            _connection = connection;
        }

        /*public Galaxy GetGalaxy(Guid id)
        {
            _connection.Connection[nameof(GalaxyHub)].Call()
        } */
    }
}