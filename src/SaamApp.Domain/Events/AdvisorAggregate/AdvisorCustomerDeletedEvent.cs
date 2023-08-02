using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorCustomerDeletedEvent : BaseDomainEvent
    {
        public AdvisorCustomerDeletedEvent(AdvisorCustomer advisorCustomer, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorCustomer";
            Content = JsonConvert.SerializeObject(advisorCustomer, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorCustomerDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}