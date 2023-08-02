using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class EmployeeAddressCreatedEvent : BaseDomainEvent
    {
        public EmployeeAddressCreatedEvent(EmployeeAddress employeeAddress, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "EmployeeAddress";
            Content = JsonConvert.SerializeObject(employeeAddress, JsonSerializerSettingsSingleton.Instance);
            EventType = "EmployeeAddressCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}