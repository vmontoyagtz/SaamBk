using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace SaamBlazor.UI.Client.Common
{
    public class BlazorServerSignalRService
    {
        private HubConnection _hubConnection;

        public BlazorServerSignalRService()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7278/blazorHub")
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

        public async Task FromClientSendMessageToOthersConnectedToBlazorServerAsync(string message)
        {
            if (_hubConnection.State == HubConnectionState.Connected)
            {
                await _hubConnection.SendAsync("FromClientSendMessageBlazorServer", message);
            }
            else
            {
               
                Console.WriteLine("Cannot send message. Connection is not active.");
            }
        }

        public void OnMessageReceived(Action<string> handler)
        {
            _hubConnection.On("ReceiveMessageFromBlazorServer", handler);
        }

        public void RemoveMessageReceivedHandler()
        {
            _hubConnection.Remove("ReceiveMessageFromBlazorServer");
        }
    }
}