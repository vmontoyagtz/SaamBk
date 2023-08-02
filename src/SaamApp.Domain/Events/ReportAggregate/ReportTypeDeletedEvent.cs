using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class ReportTypeDeletedEvent : BaseDomainEvent
    {
        public ReportTypeDeletedEvent(ReportType reportType, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "ReportType";
            Content = JsonConvert.SerializeObject(reportType, JsonSerializerSettingsSingleton.Instance);
            EventType = "ReportTypeDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}