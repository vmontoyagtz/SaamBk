using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class ComissionDeletedEvent : BaseDomainEvent
    {
        public ComissionDeletedEvent(Comission comission, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Comission";
            Content = JsonConvert.SerializeObject(comission, JsonSerializerSettingsSingleton.Instance);
            EventType = "ComissionDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}