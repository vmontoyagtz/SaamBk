using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class EmployeeEmailAddressCreatedEvent : BaseDomainEvent
    {
        public EmployeeEmailAddressCreatedEvent(EmployeeEmailAddress employeeEmailAddress, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "EmployeeEmailAddress";
            Content = JsonConvert.SerializeObject(employeeEmailAddress, JsonSerializerSettingsSingleton.Instance);
            EventType = "EmployeeEmailAddressCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}