using Microsoft.AspNetCore.SignalR.Client;

namespace SaamApp.Maui.Client.Common
{
    public class SaamApiSignalRService
    {
        private HubConnection _hubConnection;


        public SaamApiSignalRService()
        {
           
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

           

            var baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:5257/" : "https://localhost:5257/";

            var httpClient = new HttpClient(handler);

            _hubConnection = new HubConnectionBuilder()
                .WithUrl(baseAddress + "saamApiSignalrHub", options =>
                {
                    options.HttpMessageHandlerFactory = _ => handler;
                })
                .Build();

        }

        public HubConnectionState ConnectionState => _hubConnection.State;

        public async Task ConnectAsync()
        {
            //_hubConnection = new HubConnectionBuilder()
            //    .WithUrl("https://localhost:5257/saamApiSignalrHub")
            //    .Build();

            try
            {
                await _hubConnection.StartAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DisconnectAsync()
        {
            try
            {
                await _hubConnection.StopAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine(ex.Message);
            }
        }

        public async Task FromClientSendMessageToOthersConnectedToSaamApiServerAsync(string message)
        {
            if (_hubConnection.State == HubConnectionState.Connected)
            {
                await _hubConnection.SendAsync("FromClientSendMessageToOthersConnectedToSaamApiAsync", message);
            }
            else
            {
                // Handle the case where the connection is not active
                Console.WriteLine("Cannot send message. Connection is not active.");
            }
        }

        public void OnMessageReceived(Action<string> handler)
        {
            Console.WriteLine("Oscar client");

            _hubConnection.On("ReceiveMessageFromApiServer", handler);
        }

        public void RemoveMessageReceivedHandler()
        {
            _hubConnection.Remove("ReceiveMessageFromApiServer");
        }
    }
}