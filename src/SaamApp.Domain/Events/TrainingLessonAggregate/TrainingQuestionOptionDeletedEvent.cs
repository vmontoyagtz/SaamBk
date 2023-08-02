using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class TrainingQuestionOptionDeletedEvent : BaseDomainEvent
    {
        public TrainingQuestionOptionDeletedEvent(TrainingQuestionOption trainingQuestionOption, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "TrainingQuestionOption";
            Content = JsonConvert.SerializeObject(trainingQuestionOption, JsonSerializerSettingsSingleton.Instance);
            EventType = "TrainingQuestionOptionDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}