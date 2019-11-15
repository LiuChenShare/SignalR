using Microsoft.AspNetCore.SignalR;
using SignalRHost.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHost.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendAllMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveAllMessage", user, message);
        }

        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public async Task Register(Guid clientId)
        {
            //if (CentralizedData.Instance.ClientAddress.ContainsKey(clientId))
            //{
            //    ClientData.Instance.ClientAddress[clientId] = Context.ConnectionId;
            //}
            //else
            //{
            //    ClientData.Instance.ClientAddress.Add(clientId, Context.ConnectionId);
            //}
            //await Clients.Caller.SendAsync("RegisterNotice", ClientData.Instance.ClientAddress.Count());
            //await Clients.All.SendAsync("ServerNotice", "欢迎" + clientId.ToString() + "加入房间");
            //ConsoleHelper.WriteSuccessLine(clientId.ToString() + "加入房间");
        }
    }
}
