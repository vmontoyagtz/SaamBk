using System;
using Newtonsoft.Json;

namespace SaamAppLib.SharedKernel
{
    public class GenericOccuredEvent : BaseDomainEvent
    {
        public GenericOccuredEvent(object entity, string action, string entityname, string consumer, string eventtype)
        {
            ActionOnMessageReceived = action;
            EntityNameType = entityname;
            Consumer = consumer;
            Content = JsonConvert.SerializeObject(entity, JsonSerializerSettingsSingleton.Instance);
            EventType = eventtype;
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}