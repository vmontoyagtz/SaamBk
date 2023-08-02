using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class ReportTypeCreatedEvent : BaseDomainEvent
    {
        public ReportTypeCreatedEvent(ReportType reportType, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "ReportType";
            Content = JsonConvert.SerializeObject(reportType, JsonSerializerSettingsSingleton.Instance);
            EventType = "ReportTypeCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}