using MediatR;

namespace SaamAppLib.SharedKernel
{
    //https://learn.microsoft.com/en-us/ef/core/modeling/keyless-entity-types?tabs=data-annotations
    //[Keyless]
    public abstract class BaseDomainEvent : OutBoxMessage, INotification
    {
    }
}