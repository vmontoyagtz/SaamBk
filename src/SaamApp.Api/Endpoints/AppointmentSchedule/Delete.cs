using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AppointmentSchedule;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AppointmentScheduleEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAppointmentScheduleRequest>.WithActionResult<
        DeleteAppointmentScheduleResponse>
    {
        private readonly IRepository<AppointmentSchedule> _appointmentScheduleReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AppointmentSchedule> _repository;

        public Delete(IRepository<AppointmentSchedule> AppointmentScheduleRepository,
            IRepository<AppointmentSchedule> AppointmentScheduleReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AppointmentScheduleRepository;
            _appointmentScheduleReadRepository = AppointmentScheduleReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/appointmentSchedules/{AppointmentScheduleId}")]
        [SwaggerOperation(
            Summary = "Deletes an AppointmentSchedule",
            Description = "Deletes an AppointmentSchedule",
            OperationId = "appointmentSchedules.delete",
            Tags = new[] { "AppointmentScheduleEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAppointmentScheduleResponse>> HandleAsync(
            [FromRoute] DeleteAppointmentScheduleRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAppointmentScheduleResponse(request.CorrelationId());

            var appointmentSchedule =
                await _appointmentScheduleReadRepository.GetByIdAsync(request.AppointmentScheduleId);

            if (appointmentSchedule == null)
            {
                return NotFound();
            }


            var appointmentScheduleDeletedEvent =
                new AppointmentScheduleDeletedEvent(appointmentSchedule, "Mongo-History");
            _messagePublisher.Publish(appointmentScheduleDeletedEvent);

            await _repository.DeleteAsync(appointmentSchedule);

            return Ok(response);
        }
    }
}