using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class DiscountCodeCreatedEvent : BaseDomainEvent
    {
        public DiscountCodeCreatedEvent(DiscountCode discountCode, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "DiscountCode";
            Content = JsonConvert.SerializeObject(discountCode, JsonSerializerSettingsSingleton.Instance);
            EventType = "DiscountCodeCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}