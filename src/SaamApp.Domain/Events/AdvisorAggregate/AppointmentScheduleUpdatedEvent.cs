using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AppointmentScheduleUpdatedEvent : BaseDomainEvent
    {
        public AppointmentScheduleUpdatedEvent(AppointmentSchedule appointmentSchedule, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AppointmentSchedule";
            Content = JsonConvert.SerializeObject(appointmentSchedule, JsonSerializerSettingsSingleton.Instance);
            EventType = "AppointmentScheduleUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}