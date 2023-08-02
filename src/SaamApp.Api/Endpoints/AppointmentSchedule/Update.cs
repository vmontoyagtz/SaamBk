using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AppointmentSchedule;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AppointmentScheduleEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAppointmentScheduleRequest>.WithActionResult<
        UpdateAppointmentScheduleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AppointmentSchedule> _repository;

        public Update(
            IRepository<AppointmentSchedule> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/appointmentSchedules")]
        [SwaggerOperation(
            Summary = "Updates a AppointmentSchedule",
            Description = "Updates a AppointmentSchedule",
            OperationId = "appointmentSchedules.update",
            Tags = new[] { "AppointmentScheduleEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAppointmentScheduleResponse>> HandleAsync(
            UpdateAppointmentScheduleRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateAppointmentScheduleResponse(request.CorrelationId());

            var aspspsToUpdate = _mapper.Map<AppointmentSchedule>(request);

            var appointmentScheduleToUpdateTest = await _repository.GetByIdAsync(request.AppointmentScheduleId);
            if (appointmentScheduleToUpdateTest is null)
            {
                return NotFound();
            }

            aspspsToUpdate.UpdateAdvisorForAppointmentSchedule(request.AdvisorId);
            aspspsToUpdate.UpdateCustomerForAppointmentSchedule(request.CustomerId);
            await _repository.UpdateAsync(aspspsToUpdate);

            var appointmentScheduleUpdatedEvent = new AppointmentScheduleUpdatedEvent(aspspsToUpdate, "Mongo-History");
            _messagePublisher.Publish(appointmentScheduleUpdatedEvent);

            var dto = _mapper.Map<AppointmentScheduleDto>(aspspsToUpdate);
            response.AppointmentSchedule = dto;

            return Ok(response);
        }
    }
}