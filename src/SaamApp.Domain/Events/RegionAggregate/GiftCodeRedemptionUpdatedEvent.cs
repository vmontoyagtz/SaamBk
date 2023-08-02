using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class GiftCodeRedemptionUpdatedEvent : BaseDomainEvent
    {
        public GiftCodeRedemptionUpdatedEvent(GiftCodeRedemption giftCodeRedemption, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "GiftCodeRedemption";
            Content = JsonConvert.SerializeObject(giftCodeRedemption, JsonSerializerSettingsSingleton.Instance);
            EventType = "GiftCodeRedemptionUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}