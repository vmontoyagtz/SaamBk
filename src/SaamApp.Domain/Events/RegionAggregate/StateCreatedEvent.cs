using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class StateCreatedEvent : BaseDomainEvent
    {
        public StateCreatedEvent(State state, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "State";
            Content = JsonConvert.SerializeObject(state, JsonSerializerSettingsSingleton.Instance);
            EventType = "StateCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}