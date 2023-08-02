using KafkaCassandraService.Web.Models;

namespace KafkaCassandraService.Web.Interfaces
{
  public interface ISendConfirmationEmails
    {
        void SendConfirmationEmail(SendAppointmentConfirmationCommand appointment);
    }
}
