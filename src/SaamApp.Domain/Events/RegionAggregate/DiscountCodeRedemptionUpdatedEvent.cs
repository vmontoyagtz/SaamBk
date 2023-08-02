using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class DiscountCodeRedemptionUpdatedEvent : BaseDomainEvent
    {
        public DiscountCodeRedemptionUpdatedEvent(DiscountCodeRedemption discountCodeRedemption, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "DiscountCodeRedemption";
            Content = JsonConvert.SerializeObject(discountCodeRedemption, JsonSerializerSettingsSingleton.Instance);
            EventType = "DiscountCodeRedemptionUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}