using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class EmployeePhoneNumberDeletedEvent : BaseDomainEvent
    {
        public EmployeePhoneNumberDeletedEvent(EmployeePhoneNumber employeePhoneNumber, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "EmployeePhoneNumber";
            Content = JsonConvert.SerializeObject(employeePhoneNumber, JsonSerializerSettingsSingleton.Instance);
            EventType = "EmployeePhoneNumberDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}