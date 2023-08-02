using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class DiscountCodeRedemptionDeletedEvent : BaseDomainEvent
    {
        public DiscountCodeRedemptionDeletedEvent(DiscountCodeRedemption discountCodeRedemption, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "DiscountCodeRedemption";
            Content = JsonConvert.SerializeObject(discountCodeRedemption, JsonSerializerSettingsSingleton.Instance);
            EventType = "DiscountCodeRedemptionDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}