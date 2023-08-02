using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AiRobotCreatedEvent : BaseDomainEvent
    {
        public AiRobotCreatedEvent(AiRobot aiRobot, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AiRobot";
            Content = JsonConvert.SerializeObject(aiRobot, JsonSerializerSettingsSingleton.Instance);
            EventType = "AiRobotCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}