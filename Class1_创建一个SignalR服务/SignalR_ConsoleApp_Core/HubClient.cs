using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_ConsoleApp_Core
{
    public class HubClient
    {
        HubConnection connection;
        public void XXX()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:667/ChatHub")
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
        }


        public async void connectButton()
        {
            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                ConsoleHelper.WriteSuccessLine($"{user}: {message}");
            });
            try
            {
                await connection.StartAsync();
            }
            catch(Exception ex)
            {
                ConsoleHelper.WriteErrorLine(ex.ToString());
            }
        }

        public async void sendButton(string user, string message)
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
