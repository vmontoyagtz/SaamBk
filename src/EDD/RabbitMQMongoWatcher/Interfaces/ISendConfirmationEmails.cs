using RabbitMQMongoWatcher.Web.Models;

namespace RabbitMQMongoWatcher.Web.Interfaces
{
  public interface ISendConfirmationEmails
    {
        void SendConfirmationEmail(SendAppointmentConfirmationCommand appointment);
    }
}
