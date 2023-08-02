using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorBankDeletedEvent : BaseDomainEvent
    {
        public AdvisorBankDeletedEvent(AdvisorBank advisorBank, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorBank";
            Content = JsonConvert.SerializeObject(advisorBank, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorBankDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}