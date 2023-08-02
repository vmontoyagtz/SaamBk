using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class TrainingProgressCreatedEvent : BaseDomainEvent
    {
        public TrainingProgressCreatedEvent(TrainingProgress trainingProgress, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "TrainingProgress";
            Content = JsonConvert.SerializeObject(trainingProgress, JsonSerializerSettingsSingleton.Instance);
            EventType = "TrainingProgressCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}