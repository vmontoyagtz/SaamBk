using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class TaxInformationDeletedEvent : BaseDomainEvent
    {
        public TaxInformationDeletedEvent(TaxInformation taxInformation, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "TaxInformation";
            Content = JsonConvert.SerializeObject(taxInformation, JsonSerializerSettingsSingleton.Instance);
            EventType = "TaxInformationDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}