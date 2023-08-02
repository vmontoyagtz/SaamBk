using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class ReportDeletedEvent : BaseDomainEvent
    {
        public ReportDeletedEvent(Report report, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Report";
            Content = JsonConvert.SerializeObject(report, JsonSerializerSettingsSingleton.Instance);
            EventType = "ReportDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}