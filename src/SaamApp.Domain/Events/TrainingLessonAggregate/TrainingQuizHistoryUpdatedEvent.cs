using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class TrainingQuizHistoryUpdatedEvent : BaseDomainEvent
    {
        public TrainingQuizHistoryUpdatedEvent(TrainingQuizHistory trainingQuizHistory, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "TrainingQuizHistory";
            Content = JsonConvert.SerializeObject(trainingQuizHistory, JsonSerializerSettingsSingleton.Instance);
            EventType = "TrainingQuizHistoryUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}