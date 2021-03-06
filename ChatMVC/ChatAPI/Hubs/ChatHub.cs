using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ChatAPI.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
           await Clients.Others.SendAsync("ReceiveMessage", user, message);
        }
    }
}
