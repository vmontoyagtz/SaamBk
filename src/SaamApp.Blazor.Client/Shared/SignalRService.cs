



using Microsoft.AspNetCore.SignalR.Client;

namespace SaamBlazor.UI.Client.Shared
{
    public class SignalRService
    {
        private readonly HubConnection _hubConnection;

        public SignalRService()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://10.0.2.2:5257/SaamAppHub")
                .Build();
        }

        public async Task ConnectAsync(Action<string> onReceiveMessage)
        {
            _hubConnection.On<string>("ReceiveMessage", onReceiveMessage);
            await _hubConnection.StartAsync();
        }

        public async Task DisconnectAsync()
        {
            await _hubConnection.StopAsync();
        }
    }
}
