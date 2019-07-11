using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRChat_WebApp_Core.Hubs
{
    public class ChatHub : Hub
    {
        #region snippet_SendMessage
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        #endregion
    }
}
