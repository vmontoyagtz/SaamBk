using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class EmployeePhoneNumberUpdatedEvent : BaseDomainEvent
    {
        public EmployeePhoneNumberUpdatedEvent(EmployeePhoneNumber employeePhoneNumber, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "EmployeePhoneNumber";
            Content = JsonConvert.SerializeObject(employeePhoneNumber, JsonSerializerSettingsSingleton.Instance);
            EventType = "EmployeePhoneNumberUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}