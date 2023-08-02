using System;

namespace RabbitMQMongoWatcher.Web.Models
{
    public class AppointmentConfirmLinkClickedIntegrationEvent
    {
        public AppointmentConfirmLinkClickedIntegrationEvent(Guid appointmentId)
        {
            this.Id = Guid.NewGuid();
            DateTimeEventOccurred = DateTime.Now;
            this.AppointmentId = appointmentId;
        }

        public Guid Id { get; private set; }
        public DateTimeOffset DateTimeEventOccurred { get; set; }
        public Guid AppointmentId { get; set; }
        public string EventType => nameof(AppointmentConfirmLinkClickedIntegrationEvent);
    }
}
