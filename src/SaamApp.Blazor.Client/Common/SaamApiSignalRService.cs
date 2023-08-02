using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace SaamBlazor.UI.Client.Common
{
    public class SaamApiSignalRService
    {
        private HubConnection _hubConnection;


        public SaamApiSignalRService()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5257/saamApiSignalrHub")
                .Build();

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
            try
            {
                await _hubConnection.StopAsync();
            }
            catch (Exception ex)
            {
                
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