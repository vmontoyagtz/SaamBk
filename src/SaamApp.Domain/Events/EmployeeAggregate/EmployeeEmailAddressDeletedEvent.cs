using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class EmployeeEmailAddressDeletedEvent : BaseDomainEvent
    {
        public EmployeeEmailAddressDeletedEvent(EmployeeEmailAddress employeeEmailAddress, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "EmployeeEmailAddress";
            Content = JsonConvert.SerializeObject(employeeEmailAddress, JsonSerializerSettingsSingleton.Instance);
            EventType = "EmployeeEmailAddressDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}