using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class EmployeeAddressUpdatedEvent : BaseDomainEvent
    {
        public EmployeeAddressUpdatedEvent(EmployeeAddress employeeAddress, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "EmployeeAddress";
            Content = JsonConvert.SerializeObject(employeeAddress, JsonSerializerSettingsSingleton.Instance);
            EventType = "EmployeeAddressUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}