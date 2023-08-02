using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorCustomerUpdatedEvent : BaseDomainEvent
    {
        public AdvisorCustomerUpdatedEvent(AdvisorCustomer advisorCustomer, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorCustomer";
            Content = JsonConvert.SerializeObject(advisorCustomer, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorCustomerUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}