using System.Diagnostics;
using Microsoft.AspNetCore.SignalR.Client;
using SaamApp.Maui.Client.Customer;


namespace SaamApp.Maui.Client.Common
{
    public class BlazorServerSignalRService
    {
        private HubConnection _hubConnection;
     
        public event Action<string> MessageReceived;
        public BlazorServerSignalRService()
        {
           
          

            /* var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

          
            var baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7278/" : "https://localhost:7278/";

            var httpClient = new HttpClient(handler);

            _hubConnection = new HubConnectionBuilder()
                .WithUrl(baseAddress + "blazorHub", options =>
                {
                    options.HttpMessageHandlerFactory = _ => handler;
                })
                .Build();



            OnMessageReceived(null);

            _hubConnection.StartAsync().GetAwaiter().GetResult(); */
        }

        public HubConnectionState ConnectionState => _hubConnection.State;

        public async Task ConnectAsync()
        {
     

            try
            {
                await _hubConnection.StartAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DisconnectAsync()
        {
            Debug.WriteLine("maui DisconnectAsync ");
            try
            {
                await _hubConnection.StopAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public async Task FromClientSendMessageToOthersConnectedToBlazorServerAsync(string message)
        {
            if (_hubConnection.State == HubConnectionState.Connected)
            {
                Debug.WriteLine("Maui FromClientSendMessageBlazorServer");
                await _hubConnection.SendAsync("FromClientSendMessageBlazorServer", message);
            }
            else
            {
                // Handle the case where the connection is not active
                Console.WriteLine("Cannot send message. Connection is not active.");
            }
        }

        public void OnMessageReceived(Action<string> handler)
        {
          

            Debug.WriteLine("maui ReceiveMessageFromBlazorServer OnMessageReceived ");
            _hubConnection.On("ReceiveMessageFromBlazorServer", (Action<string>)(message =>
            {

           
                MessageReceived?.Invoke(message);
            }));

        }

        public void RemoveMessageReceivedHandler()
        {

            Debug.WriteLine("maui RemoveMessageReceivedHandler ");
            _hubConnection.Remove("ReceiveMessageFromBlazorServer");
        }
    }
}