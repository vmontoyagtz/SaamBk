using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class TaxInformationUpdatedEvent : BaseDomainEvent
    {
        public TaxInformationUpdatedEvent(TaxInformation taxInformation, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "TaxInformation";
            Content = JsonConvert.SerializeObject(taxInformation, JsonSerializerSettingsSingleton.Instance);
            EventType = "TaxInformationUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}