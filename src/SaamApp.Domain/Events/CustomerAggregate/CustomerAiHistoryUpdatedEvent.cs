using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CustomerAiHistoryUpdatedEvent : BaseDomainEvent
    {
        public CustomerAiHistoryUpdatedEvent(CustomerAiHistory customerAiHistory, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "CustomerAiHistory";
            Content = JsonConvert.SerializeObject(customerAiHistory, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerAiHistoryUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}