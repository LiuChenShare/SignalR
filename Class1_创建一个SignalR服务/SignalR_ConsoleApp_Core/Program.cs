using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace SignalR_ConsoleApp_Core
{
    class Program
    {
        HubConnection connection;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

        }

        private void XXX()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:53353/ChatHub")
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
        }

        
        private async void connectButton()
        {
            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Console.WriteLine($"{user}: {message}");
            });

            await connection.StartAsync();
        }

        private async void sendButton(string user, string message)
        {
            try
            {
                await connection.InvokeAsync("SendMessage", user, message);
            }
            catch (Exception ex)
            {
                //ConsoleHelper.WriteErrorLine($"{user}: {message}");

                ConsoleHelper.WriteErrorLine(ex.ToString());
            }
        }
    }
    
}
