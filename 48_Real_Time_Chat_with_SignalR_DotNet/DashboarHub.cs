using Microsoft.AspNetCore.SignalR;

namespace WebApplication6
{
    public class DashboardHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
