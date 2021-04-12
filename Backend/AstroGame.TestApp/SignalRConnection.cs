using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace AstroGame.TestApp
{
    public class SignalRConnection
    {
        public async void Start()
        {
            var url = "https://localhost:7555/hub/building";

            var connection = new HubConnectionBuilder()
                .WithUrl(url, options =>
                {
                    options.AccessTokenProvider = () => Task.FromResult("eyJhbGciOiJSUzI1NiIsImtpZCI6IjU0QkRGQjU4NzlFOTY2ODQ2NDg2MzlGMkNCQ0IxNzQzIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE2MTc4NzM5NTEsImV4cCI6MTYxNzg3NzU1MSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzU1NiIsImF1ZCI6ImFzdHJvZ2FtZS5hcGkiLCJjbGllbnRfaWQiOiJhc3Ryb2dhbWUuYXBwIiwic3ViIjoiMjIyMjIyMjItMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAwIiwiYXV0aF90aW1lIjoxNjE3ODczOTUxLCJpZHAiOiJBdXRoU2VydmVyIiwianRpIjoiQzdDMDQ0NkIxQzQ2NkY1NEIwNEREMzU5MzRCNDYxMkYiLCJpYXQiOjE2MTc4NzM5NTEsInNjb3BlIjpbImFzdHJvZ2FtZS5hcGkiLCJvZmZsaW5lX2FjY2VzcyJdLCJhbXIiOlsid2hhdCJdfQ.kXPfwWfTx7FjEqAZPjntIb5kyEmh6-3hK6iYgSTI229Q07t4Zu9Lay07qU1PHgGKWdWFB5SYj_QF6abSLJtk2APrjmcIs2Xulzz83zedjxYzJJWhDpntDfJD_WPtiPPuOsRQBVR-LbVgK3Jbj1nsJJTcU-TouC8V80GCF3khXLr1Pj9PKdbtFdk5BDw39nhoTnbKDhBju4McEpGvIkbENpRXNc5fd-ABCFi1pyBGNIqm8U3wOndpSze3oU9iUekLsbrIslALqqEMJFC65ZR3uKbXcIHSsjbq8P45qPOAmtPRQbHb07ymBCS2aYN--YE8Hdlx7YQ7a6xXsiA6uCOehQ");
                })
                .WithAutomaticReconnect()
                .Build();

            // receive a message from the hub
            connection.On<string, string>("BuildingConstructionFinished", (user, message) => OnReceiveMessage(user, message));

            var t = connection.StartAsync();

            t.Wait();

            // send a message to the hub
            //await connection.InvokeAsync("SendMessage", "ConsoleApp", "Message from the console app");
        }

        private void OnReceiveMessage(string user, string message)
        {
            Console.WriteLine($"{user}: {message}");
        }

    }
}
