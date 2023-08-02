using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CustomerAiHistoryDeletedEvent : BaseDomainEvent
    {
        public CustomerAiHistoryDeletedEvent(CustomerAiHistory customerAiHistory, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "CustomerAiHistory";
            Content = JsonConvert.SerializeObject(customerAiHistory, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerAiHistoryDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}