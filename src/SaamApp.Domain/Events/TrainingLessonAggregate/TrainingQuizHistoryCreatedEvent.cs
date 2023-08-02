using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class TrainingQuizHistoryCreatedEvent : BaseDomainEvent
    {
        public TrainingQuizHistoryCreatedEvent(TrainingQuizHistory trainingQuizHistory, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "TrainingQuizHistory";
            Content = JsonConvert.SerializeObject(trainingQuizHistory, JsonSerializerSettingsSingleton.Instance);
            EventType = "TrainingQuizHistoryCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}