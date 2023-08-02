using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class PrepaidPackageDeletedEvent : BaseDomainEvent
    {
        public PrepaidPackageDeletedEvent(PrepaidPackage prepaidPackage, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "PrepaidPackage";
            Content = JsonConvert.SerializeObject(prepaidPackage, JsonSerializerSettingsSingleton.Instance);
            EventType = "PrepaidPackageDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}