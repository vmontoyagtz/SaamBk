using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class ReportCreatedEvent : BaseDomainEvent
    {
        public ReportCreatedEvent(Report report, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Report";
            Content = JsonConvert.SerializeObject(report, JsonSerializerSettingsSingleton.Instance);
            EventType = "ReportCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}