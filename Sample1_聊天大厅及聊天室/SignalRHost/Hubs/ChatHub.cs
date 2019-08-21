using Microsoft.AspNetCore.SignalR;
using SignalRHost.Data;
using SignalRHost.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHost.Hubs
{
    public class ChatHub : Hub
    {
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public async Task Register(Guid clientId)
        {
            if (ClientData.Instance.ClientAddress.ContainsKey(clientId))
            {
                ClientData.Instance.ClientAddress[clientId] = Context.ConnectionId;
            }
            else
            {
                ClientData.Instance.ClientAddress.Add(clientId, Context.ConnectionId);
            }
            await Clients.Caller.SendAsync("RegisterNotice", ClientData.Instance.ClientAddress.Count());
            await Clients.All.SendAsync("ServerNotice", "欢迎" + clientId.ToString() + "加入房间");
            ConsoleHelper.WriteSuccessLine(clientId.ToString() + "加入房间");
        }

        /// <summary>
        /// 广播消息
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessage(string user, string message)
        {
            //await Clients.All.SendAsync("ReceiveMessage", user, message);
            var clients = ClientData.Instance.ClientAddress.Values.ToArray();
            await Clients.Clients(clients).SendAsync("ReceiveMessage", user, message, ClientData.Instance.ClientAddress.Count());
            ConsoleHelper.WriteInfoLine(string.Format("{0}say：{1}", user, message));
        }

        /// <summary>
        /// 当与集线器建立新连接时调用
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
        {
            //await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }

        /// <summary>
        /// 在与集线器的连接终止时调用
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            //await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
            if (ClientData.Instance.ClientAddress.ContainsValue(Context.ConnectionId))
            {
                var keys = ClientData.Instance.ClientAddress.Where(a => a.Value == Context.ConnectionId).Select(q => q.Key).ToList();
                foreach (var key in keys)
                {
                    ClientData.Instance.ClientAddress.Remove(key, out string connectionId);
                    await Clients.All.SendAsync("ServerNotice", key.ToString() + "已离线");
                    ConsoleHelper.WriteWarningLine(key.ToString() + "离开房间");
                }
            }
            await base.OnDisconnectedAsync(exception);
        }
    }
}
