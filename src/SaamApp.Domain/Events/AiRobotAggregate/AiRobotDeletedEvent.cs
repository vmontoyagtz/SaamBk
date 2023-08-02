using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AiRobotDeletedEvent : BaseDomainEvent
    {
        public AiRobotDeletedEvent(AiRobot aiRobot, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AiRobot";
            Content = JsonConvert.SerializeObject(aiRobot, JsonSerializerSettingsSingleton.Instance);
            EventType = "AiRobotDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}