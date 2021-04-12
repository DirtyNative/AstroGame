using System;

namespace AstroGame.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var signalRConnection = new SignalRConnection();
            signalRConnection.Start();

            Console.Read();
        }
    }
}
