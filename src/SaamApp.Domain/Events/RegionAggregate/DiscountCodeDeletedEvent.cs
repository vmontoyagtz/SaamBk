using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class DiscountCodeDeletedEvent : BaseDomainEvent
    {
        public DiscountCodeDeletedEvent(DiscountCode discountCode, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "DiscountCode";
            Content = JsonConvert.SerializeObject(discountCode, JsonSerializerSettingsSingleton.Instance);
            EventType = "DiscountCodeDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}