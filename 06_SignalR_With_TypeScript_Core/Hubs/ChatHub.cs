using Microsoft.AspNetCore.SignalR;
namespace _06_SignalR_With_TypeScript_Core.Hubs
{
    public class ChatHub : Hub
    {
        public async Task NewMessage(long username, string message) =>
            await Clients.All.SendAsync("messageReceived", username, message);

    }
}
