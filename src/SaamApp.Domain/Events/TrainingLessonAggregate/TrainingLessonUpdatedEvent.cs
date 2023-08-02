using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class TrainingLessonUpdatedEvent : BaseDomainEvent
    {
        public TrainingLessonUpdatedEvent(TrainingLesson trainingLesson, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "TrainingLesson";
            Content = JsonConvert.SerializeObject(trainingLesson, JsonSerializerSettingsSingleton.Instance);
            EventType = "TrainingLessonUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}