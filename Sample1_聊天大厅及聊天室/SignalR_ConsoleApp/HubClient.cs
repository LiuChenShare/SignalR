using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_ConsoleApp
{

    public class HubClient
    {
        Microsoft.AspNetCore.SignalR.Client.HubConnection connection;

        public Guid GuidId { get; set; } = Guid.NewGuid();

        public HubClient()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:667/ChatHub")
                .Build();

            connection.Closed += async (error) =>
            {
                ConsoleHelper.WriteErrorLine("客户端已离线，即将自动重连 ... ...");
                await Task.Delay(new Random().Next(0, 5) * 1000);
                ConsoleHelper.WriteErrorLine("启动自动重连 ... ...");
                try
                {
                    await connection.StartAsync();
                    Register();
                }
                catch (Exception ex)
                {
                    ConsoleHelper.WriteErrorLine(ex.ToString());
                }
            };
        }


        public async void connectButton()
        {
            connection.On<string, string, int>("ReceiveMessage", (user, message, clientCount) =>
            {
                ConsoleHelper.WriteSuccessLine($"{user}: {message}    当前在线【{clientCount}】");
            });
            //服务注册通知
            connection.On<int>("RegisterNotice", (message) =>
            {
                ConsoleHelper.WriteSuccessLine($"连接成功，当前在线客户端总数：{message.ToString()}");
            });
            //系统通知
            connection.On<int>("ServerNotice", (message) =>
            {
                ConsoleHelper.WriteWarningLine($"系统通知：{message.ToString()}");
            });
            try
            {
                await connection.StartAsync();
                Register();
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteErrorLine(ex.ToString());
            }
        }

        /// <summary>
        /// 向广播室注册
        /// </summary>
        public async void Register()
        {
            try
            {
                await connection.InvokeAsync("Register", GuidId);
            }
            catch (Exception ex)
            {
                //ConsoleHelper.WriteErrorLine($"{user}: {message}");

                ConsoleHelper.WriteErrorLine(ex.ToString());
            }
        }

        /// <summary>
        /// 向广播室发送消息
        /// </summary>
        /// <param name="message"></param>
        public async void SendMessage(string message)
        {
            try
            {
                await connection.InvokeAsync("SendMessage", GuidId.ToString(), message);
            }
            catch (Exception ex)
            {
                //ConsoleHelper.WriteErrorLine($"{user}: {message}");

                ConsoleHelper.WriteErrorLine(ex.ToString());
            }
        }


    }
}
