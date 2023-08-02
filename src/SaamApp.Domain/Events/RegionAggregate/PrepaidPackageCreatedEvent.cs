using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class PrepaidPackageCreatedEvent : BaseDomainEvent
    {
        public PrepaidPackageCreatedEvent(PrepaidPackage prepaidPackage, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "PrepaidPackage";
            Content = JsonConvert.SerializeObject(prepaidPackage, JsonSerializerSettingsSingleton.Instance);
            EventType = "PrepaidPackageCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}