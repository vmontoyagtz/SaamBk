using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class TrainingProgressDeletedEvent : BaseDomainEvent
    {
        public TrainingProgressDeletedEvent(TrainingProgress trainingProgress, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "TrainingProgress";
            Content = JsonConvert.SerializeObject(trainingProgress, JsonSerializerSettingsSingleton.Instance);
            EventType = "TrainingProgressDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}