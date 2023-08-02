using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class TaxpayerTypeUpdatedEvent : BaseDomainEvent
    {
        public TaxpayerTypeUpdatedEvent(TaxpayerType taxpayerType, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "TaxpayerType";
            Content = JsonConvert.SerializeObject(taxpayerType, JsonSerializerSettingsSingleton.Instance);
            EventType = "TaxpayerTypeUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}