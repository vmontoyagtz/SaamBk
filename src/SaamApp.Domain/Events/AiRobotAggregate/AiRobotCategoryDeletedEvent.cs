using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AiRobotCategoryDeletedEvent : BaseDomainEvent
    {
        public AiRobotCategoryDeletedEvent(AiRobotCategory aiRobotCategory, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AiRobotCategory";
            Content = JsonConvert.SerializeObject(aiRobotCategory, JsonSerializerSettingsSingleton.Instance);
            EventType = "AiRobotCategoryDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}