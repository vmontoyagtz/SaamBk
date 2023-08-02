using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Api.ApplicationEvents
{
    public class NamedEntityUpdatedEvent : IApplicationEvent
    {
        public NamedEntityUpdatedEvent(NamedEntity entity, string eventType)
        {
            Entity = entity;
            EventType = eventType;
        }

        public NamedEntity Entity { get; set; }
        public string EventType { get; set; }
    }
}