using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class GiftCodeUpdatedEvent : BaseDomainEvent
    {
        public GiftCodeUpdatedEvent(GiftCode giftCode, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "GiftCode";
            Content = JsonConvert.SerializeObject(giftCode, JsonSerializerSettingsSingleton.Instance);
            EventType = "GiftCodeUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}