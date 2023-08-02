using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class TrainingQuestionOptionUpdatedEvent : BaseDomainEvent
    {
        public TrainingQuestionOptionUpdatedEvent(TrainingQuestionOption trainingQuestionOption, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "TrainingQuestionOption";
            Content = JsonConvert.SerializeObject(trainingQuestionOption, JsonSerializerSettingsSingleton.Instance);
            EventType = "TrainingQuestionOptionUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}