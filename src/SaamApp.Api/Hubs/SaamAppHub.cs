using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SaamApp.Api.Hubs
{
    public class SaamAppHub : Hub
    {
        public Task UpdateScheduleAsync(string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", message);
        }

        public async Task SendMessage(string message)
        {
            await Clients.Others.SendAsync("ReceiveMessage", message);
        }
    }
}