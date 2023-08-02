using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AppointmentScheduleDeletedEvent : BaseDomainEvent
    {
        public AppointmentScheduleDeletedEvent(AppointmentSchedule appointmentSchedule, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AppointmentSchedule";
            Content = JsonConvert.SerializeObject(appointmentSchedule, JsonSerializerSettingsSingleton.Instance);
            EventType = "AppointmentScheduleDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}