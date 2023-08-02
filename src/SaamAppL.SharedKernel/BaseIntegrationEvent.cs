using MediatR;

namespace SaamAppLib.SharedKernel
{
    public abstract class BaseIntegrationEvent : OutBoxMessage, INotification
    {
    }
}