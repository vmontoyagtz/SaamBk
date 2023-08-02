using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class DiscountCodeUpdatedEvent : BaseDomainEvent
    {
        public DiscountCodeUpdatedEvent(DiscountCode discountCode, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "DiscountCode";
            Content = JsonConvert.SerializeObject(discountCode, JsonSerializerSettingsSingleton.Instance);
            EventType = "DiscountCodeUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}