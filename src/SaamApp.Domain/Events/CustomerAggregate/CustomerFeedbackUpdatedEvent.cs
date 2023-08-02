using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CustomerFeedbackUpdatedEvent : BaseDomainEvent
    {
        public CustomerFeedbackUpdatedEvent(CustomerFeedback customerFeedback, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "CustomerFeedback";
            Content = JsonConvert.SerializeObject(customerFeedback, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerFeedbackUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}