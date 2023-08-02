using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class PrepaidPackageRedemptionUpdatedEvent : BaseDomainEvent
    {
        public PrepaidPackageRedemptionUpdatedEvent(PrepaidPackageRedemption prepaidPackageRedemption, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "PrepaidPackageRedemption";
            Content = JsonConvert.SerializeObject(prepaidPackageRedemption, JsonSerializerSettingsSingleton.Instance);
            EventType = "PrepaidPackageRedemptionUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}