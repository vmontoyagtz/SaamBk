using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class ComissionUpdatedEvent : BaseDomainEvent
    {
        public ComissionUpdatedEvent(Comission comission, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Comission";
            Content = JsonConvert.SerializeObject(comission, JsonSerializerSettingsSingleton.Instance);
            EventType = "ComissionUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}