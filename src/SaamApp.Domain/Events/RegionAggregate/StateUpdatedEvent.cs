using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class StateUpdatedEvent : BaseDomainEvent
    {
        public StateUpdatedEvent(State state, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "State";
            Content = JsonConvert.SerializeObject(state, JsonSerializerSettingsSingleton.Instance);
            EventType = "StateUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}