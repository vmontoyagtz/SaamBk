using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AiFeedbackDeletedEvent : BaseDomainEvent
    {
        public AiFeedbackDeletedEvent(AiFeedback aiFeedback, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AiFeedback";
            Content = JsonConvert.SerializeObject(aiFeedback, JsonSerializerSettingsSingleton.Instance);
            EventType = "AiFeedbackDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}