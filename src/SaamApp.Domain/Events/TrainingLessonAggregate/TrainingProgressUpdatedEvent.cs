using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class TrainingProgressUpdatedEvent : BaseDomainEvent
    {
        public TrainingProgressUpdatedEvent(TrainingProgress trainingProgress, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "TrainingProgress";
            Content = JsonConvert.SerializeObject(trainingProgress, JsonSerializerSettingsSingleton.Instance);
            EventType = "TrainingProgressUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}