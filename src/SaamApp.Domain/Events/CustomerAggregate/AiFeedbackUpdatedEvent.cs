using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AiFeedbackUpdatedEvent : BaseDomainEvent
    {
        public AiFeedbackUpdatedEvent(AiFeedback aiFeedback, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AiFeedback";
            Content = JsonConvert.SerializeObject(aiFeedback, JsonSerializerSettingsSingleton.Instance);
            EventType = "AiFeedbackUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}