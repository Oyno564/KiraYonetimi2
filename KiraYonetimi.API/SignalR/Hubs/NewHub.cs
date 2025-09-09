using Microsoft.AspNetCore.SignalR;

namespace KiraYonetimi.API.SignalR.Hubs
{
    public class NewHub : Hub
    {

        public async Task SendMessageAsync(string message) { 
        
        await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
