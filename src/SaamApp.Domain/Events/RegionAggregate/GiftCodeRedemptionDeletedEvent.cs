using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class GiftCodeRedemptionDeletedEvent : BaseDomainEvent
    {
        public GiftCodeRedemptionDeletedEvent(GiftCodeRedemption giftCodeRedemption, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "GiftCodeRedemption";
            Content = JsonConvert.SerializeObject(giftCodeRedemption, JsonSerializerSettingsSingleton.Instance);
            EventType = "GiftCodeRedemptionDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}