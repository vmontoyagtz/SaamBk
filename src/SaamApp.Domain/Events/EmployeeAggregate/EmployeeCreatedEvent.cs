using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class EmployeeCreatedEvent : BaseDomainEvent
    {
        public EmployeeCreatedEvent(Employee employee, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Employee";
            Content = JsonConvert.SerializeObject(employee, JsonSerializerSettingsSingleton.Instance);
            EventType = "EmployeeCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}