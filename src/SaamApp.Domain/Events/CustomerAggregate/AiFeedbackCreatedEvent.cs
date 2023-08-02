using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AiFeedbackCreatedEvent : BaseDomainEvent
    {
        public AiFeedbackCreatedEvent(AiFeedback aiFeedback, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AiFeedback";
            Content = JsonConvert.SerializeObject(aiFeedback, JsonSerializerSettingsSingleton.Instance);
            EventType = "AiFeedbackCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}