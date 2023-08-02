using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class TrainingQuestionDeletedEvent : BaseDomainEvent
    {
        public TrainingQuestionDeletedEvent(TrainingQuestion trainingQuestion, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "TrainingQuestion";
            Content = JsonConvert.SerializeObject(trainingQuestion, JsonSerializerSettingsSingleton.Instance);
            EventType = "TrainingQuestionDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}