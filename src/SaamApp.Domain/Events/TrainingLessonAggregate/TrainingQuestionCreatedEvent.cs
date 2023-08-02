using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class TrainingQuestionCreatedEvent : BaseDomainEvent
    {
        public TrainingQuestionCreatedEvent(TrainingQuestion trainingQuestion, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "TrainingQuestion";
            Content = JsonConvert.SerializeObject(trainingQuestion, JsonSerializerSettingsSingleton.Instance);
            EventType = "TrainingQuestionCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}