using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class TrainingLessonDeletedEvent : BaseDomainEvent
    {
        public TrainingLessonDeletedEvent(TrainingLesson trainingLesson, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "TrainingLesson";
            Content = JsonConvert.SerializeObject(trainingLesson, JsonSerializerSettingsSingleton.Instance);
            EventType = "TrainingLessonDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}