using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CustomerAiHistoryCreatedEvent : BaseDomainEvent
    {
        public CustomerAiHistoryCreatedEvent(CustomerAiHistory customerAiHistory, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "CustomerAiHistory";
            Content = JsonConvert.SerializeObject(customerAiHistory, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerAiHistoryCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}