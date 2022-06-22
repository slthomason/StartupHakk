using Microsoft.AspNetCore.SignalR;

namespace _07_BlazorApp_SignalR_Core.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
