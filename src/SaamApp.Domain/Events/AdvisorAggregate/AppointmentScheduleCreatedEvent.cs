using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AppointmentScheduleCreatedEvent : BaseDomainEvent
    {
        public AppointmentScheduleCreatedEvent(AppointmentSchedule appointmentSchedule, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AppointmentSchedule";
            Content = JsonConvert.SerializeObject(appointmentSchedule, JsonSerializerSettingsSingleton.Instance);
            EventType = "AppointmentScheduleCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}