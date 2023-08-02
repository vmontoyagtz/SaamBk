using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorBankCreatedEvent : BaseDomainEvent
    {
        public AdvisorBankCreatedEvent(AdvisorBank advisorBank, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorBank";
            Content = JsonConvert.SerializeObject(advisorBank, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorBankCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}