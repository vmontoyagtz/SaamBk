using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class PrepaidPackageRedemptionCreatedEvent : BaseDomainEvent
    {
        public PrepaidPackageRedemptionCreatedEvent(PrepaidPackageRedemption prepaidPackageRedemption, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "PrepaidPackageRedemption";
            Content = JsonConvert.SerializeObject(prepaidPackageRedemption, JsonSerializerSettingsSingleton.Instance);
            EventType = "PrepaidPackageRedemptionCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}