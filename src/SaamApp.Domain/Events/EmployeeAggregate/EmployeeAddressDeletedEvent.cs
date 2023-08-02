using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class EmployeeAddressDeletedEvent : BaseDomainEvent
    {
        public EmployeeAddressDeletedEvent(EmployeeAddress employeeAddress, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "EmployeeAddress";
            Content = JsonConvert.SerializeObject(employeeAddress, JsonSerializerSettingsSingleton.Instance);
            EventType = "EmployeeAddressDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}