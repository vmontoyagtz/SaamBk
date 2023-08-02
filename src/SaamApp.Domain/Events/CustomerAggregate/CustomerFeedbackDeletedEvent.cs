using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CustomerFeedbackDeletedEvent : BaseDomainEvent
    {
        public CustomerFeedbackDeletedEvent(CustomerFeedback customerFeedback, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "CustomerFeedback";
            Content = JsonConvert.SerializeObject(customerFeedback, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerFeedbackDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}