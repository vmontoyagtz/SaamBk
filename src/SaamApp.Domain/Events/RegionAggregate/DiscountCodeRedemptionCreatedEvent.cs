using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class DiscountCodeRedemptionCreatedEvent : BaseDomainEvent
    {
        public DiscountCodeRedemptionCreatedEvent(DiscountCodeRedemption discountCodeRedemption, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "DiscountCodeRedemption";
            Content = JsonConvert.SerializeObject(discountCodeRedemption, JsonSerializerSettingsSingleton.Instance);
            EventType = "DiscountCodeRedemptionCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}