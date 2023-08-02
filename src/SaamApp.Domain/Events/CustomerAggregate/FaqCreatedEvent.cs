using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class FaqCreatedEvent : BaseDomainEvent
    {
        public FaqCreatedEvent(Faq faq, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Faq";
            Content = JsonConvert.SerializeObject(faq, JsonSerializerSettingsSingleton.Instance);
            EventType = "FaqCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}