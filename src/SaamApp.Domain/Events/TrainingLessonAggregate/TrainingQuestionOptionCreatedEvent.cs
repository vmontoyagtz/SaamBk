using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class TrainingQuestionOptionCreatedEvent : BaseDomainEvent
    {
        public TrainingQuestionOptionCreatedEvent(TrainingQuestionOption trainingQuestionOption, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "TrainingQuestionOption";
            Content = JsonConvert.SerializeObject(trainingQuestionOption, JsonSerializerSettingsSingleton.Instance);
            EventType = "TrainingQuestionOptionCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}