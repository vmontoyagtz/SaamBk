using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class TaxInformationCreatedEvent : BaseDomainEvent
    {
        public TaxInformationCreatedEvent(TaxInformation taxInformation, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "TaxInformation";
            Content = JsonConvert.SerializeObject(taxInformation, JsonSerializerSettingsSingleton.Instance);
            EventType = "TaxInformationCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}