using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class GiftCodeRedemptionCreatedEvent : BaseDomainEvent
    {
        public GiftCodeRedemptionCreatedEvent(GiftCodeRedemption giftCodeRedemption, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "GiftCodeRedemption";
            Content = JsonConvert.SerializeObject(giftCodeRedemption, JsonSerializerSettingsSingleton.Instance);
            EventType = "GiftCodeRedemptionCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}