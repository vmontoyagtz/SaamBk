using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SaamBlazor.UI.Server.Common
{
    public class BlazorServerSignalrHub: Hub
    {
     

        public async Task FromClientSendMessageBlazorServer(string message)
        {

            Debug.WriteLine("blazor hub ReceiveMessageFromBlazorServer");
            var userid = "4";
            await Clients.Others.SendAsync("ReceiveMessageFromBlazorServer", message);
        }
    }
}
