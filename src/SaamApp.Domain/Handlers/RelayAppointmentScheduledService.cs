using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace FrontDesk.Domain.Handlers
{
    /// <summary>
    ///     Post CreateConfirmationEmailMessage to message bus/queue to allow confirmation emails to be sent
    /// </summary>
    public class RelayAppointmentScheduledHandler : INotificationHandler<BaseIntegrationEvent>
    {
        // por aca es 
        // que tipo es el que manda el debcontect 

        // no pasar el dia sin agregar la familia docker

        private readonly IReadRepository<Invoice> _invoiceReadRepository;
        private readonly ILogger<RelayAppointmentScheduledHandler> _logger;


        private readonly IApplicationMessagePublisher _messagePublisher;

        public RelayAppointmentScheduledHandler(
            IReadRepository<Invoice> invoiceRepository,
            IApplicationMessagePublisher messagePublisher,
            ILogger<RelayAppointmentScheduledHandler> logger)
        {
            _invoiceReadRepository = invoiceRepository;
            _messagePublisher = messagePublisher;
            _logger = logger;
        }

        public async Task Handle(
            BaseIntegrationEvent PassedNotificationEvent,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling appointmentScheduledEvent");
            // we are translating from a domain event to an integration event here
            //var newMessage = new AppointmentScheduledIntegrationEvent();

            // no hacerlo generico
            // hacerlo asi para el click
            // estq eu no sea del BaseIntegrationEvent sino del clicked

            // luego sera otro

            // usar
            //InvoiceGetBigObjectByIdWithIncludesSpec


            // el metodo public void AddNewAppointment(Appointment appointment)


            //PassedNotificationEvent.EventId = Guid.NewGuid();


            //ActionOnMessageReceived = action;

            //EntityName = "Invoice";

            //Content = JsonConvert.SerializeObject(invoice, JsonSerializerSettingsSingleton.Instance);

            //EventType = "InvoiceCreated";

            //EventId = Guid.NewGuid();

            //OccurredOnUtc = DateTime.UtcNow;


            // if this is slow these can be parallelized or cached. MEASURE before optimizing.
            //  var doctor = await _doctorRepository.GetByIdAsync(appt.DoctorId);


            //newMessage.AppointmentId = appt.Id;
            //newMessage.AppointmentStartDateTime = PassedNotificationEvent.AppointmentScheduled.TimeRange.Start;
            //newMessage.ClientName = client.FullName;
            //newMessage.ClientEmailAddress = client.EmailAddress;
            //newMessage.DoctorName = doctor.Name;
            //newMessage.PatientName = patient.Name;
            //newMessage.AppointmentType = apptType.Name;

            //_messagePublisher.Publish(newMessage);
            //_logger.LogInformation($"Message published. {newMessage.PatientName}");
        }
    }
}