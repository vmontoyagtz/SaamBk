using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorCustomerCreatedEvent : BaseDomainEvent
    {
        public AdvisorCustomerCreatedEvent(AdvisorCustomer advisorCustomer, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorCustomer";
            Content = JsonConvert.SerializeObject(advisorCustomer, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorCustomerCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}