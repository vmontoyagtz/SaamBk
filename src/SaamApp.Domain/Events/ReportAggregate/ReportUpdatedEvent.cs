using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class ReportUpdatedEvent : BaseDomainEvent
    {
        public ReportUpdatedEvent(Report report, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Report";
            Content = JsonConvert.SerializeObject(report, JsonSerializerSettingsSingleton.Instance);
            EventType = "ReportUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}