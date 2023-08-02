using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CustomerFeedbackCreatedEvent : BaseDomainEvent
    {
        public CustomerFeedbackCreatedEvent(CustomerFeedback customerFeedback, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "CustomerFeedback";
            Content = JsonConvert.SerializeObject(customerFeedback, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerFeedbackCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}