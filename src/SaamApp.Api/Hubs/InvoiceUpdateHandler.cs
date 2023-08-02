using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using SaamApp.Domain.Events;

namespace SaamApp.Api.Hubs
{
    public class InvoiceUpdateHandler : INotificationHandler<InvoiceUpdatedEvent>
    {
        //InvoiceUpdateHandler: This is a MediatR notification handler that sends a SignalR message to all connected clients when it handles an InvoiceUpdatedEvent.
        //The SignalR message is sent with return _hubContext.Clients.All.SendAsync("ReceiveMessage",notification.EntityNameType+" was updated",cancellationToken);.
        private readonly IHubContext<SaamAppHub>
            _hubContext;

        public InvoiceUpdateHandler(IHubContext<SaamAppHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task Handle(InvoiceUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return _hubContext.Clients.All.SendAsync("ReceiveMessage",
                notification.EntityNameType + " was updated", cancellationToken);
        }
    }
}