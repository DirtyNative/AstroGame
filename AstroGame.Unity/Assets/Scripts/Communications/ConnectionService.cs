using Assets.Scripts.Hubs;
using BestHTTP.SignalR;
using System;
using UnityEngine;

namespace Assets.Scripts.Communications
{
    public class ConnectionService : MonoBehaviour
    {
        private static Uri uri = new Uri("http://localhost:5000/signalr/");
        public static Connection Connection;

        // Hubs
        private GalaxyHub _galaxyHub;

        public void Connect()
        {
        }
    }
}