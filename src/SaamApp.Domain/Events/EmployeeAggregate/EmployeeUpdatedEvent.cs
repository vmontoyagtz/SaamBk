using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class EmployeeUpdatedEvent : BaseDomainEvent
    {
        public EmployeeUpdatedEvent(Employee employee, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Employee";
            Content = JsonConvert.SerializeObject(employee, JsonSerializerSettingsSingleton.Instance);
            EventType = "EmployeeUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}