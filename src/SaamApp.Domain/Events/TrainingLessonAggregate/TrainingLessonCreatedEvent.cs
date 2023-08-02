using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class TrainingLessonCreatedEvent : BaseDomainEvent
    {
        public TrainingLessonCreatedEvent(TrainingLesson trainingLesson, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "TrainingLesson";
            Content = JsonConvert.SerializeObject(trainingLesson, JsonSerializerSettingsSingleton.Instance);
            EventType = "TrainingLessonCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}