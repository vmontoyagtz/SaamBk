using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SaamApp.Api.Hubs
{
    public class SaamApiSignalrHub : Hub
    {
        public async Task FromClientSendMessageToOthersConnectedToSaamApiAsync(string message)
        {
            await Clients.Others.SendAsync("ReceiveMessageFromApiServer", message);
        }
    }
}