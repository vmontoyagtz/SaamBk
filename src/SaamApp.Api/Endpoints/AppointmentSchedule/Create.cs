using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AppointmentSchedule;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AppointmentScheduleEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAppointmentScheduleRequest>.WithActionResult<
        CreateAppointmentScheduleResponse>
    {
        private readonly IRepository<Advisor> _advisorRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AppointmentSchedule> _repository;

        public Create(
            IRepository<AppointmentSchedule> repository,
            IRepository<Advisor> advisorRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _advisorRepository = advisorRepository;
        }

        [HttpPost("api/appointmentSchedules")]
        [SwaggerOperation(
            Summary = "Creates a new AppointmentSchedule",
            Description = "Creates a new AppointmentSchedule",
            OperationId = "appointmentSchedules.create",
            Tags = new[] { "AppointmentScheduleEndpoints" })
        ]
        public override async Task<ActionResult<CreateAppointmentScheduleResponse>> HandleAsync(
            CreateAppointmentScheduleRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAppointmentScheduleResponse(request.CorrelationId());

            //var advisor = await _advisorRepository.GetByIdAsync(request.AdvisorId);// parent entity

            var newAppointmentSchedule = new AppointmentSchedule(
                Guid.NewGuid(),
                request.AdvisorId,
                request.CustomerId,
                request.ScheduledTime,
                request.Duration,
                request.IsCancelled,
                request.CancellationReason,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted,
                request.TenantId,
                request.AppointmentStatus,
                request.Notes
            );


            await _repository.AddAsync(newAppointmentSchedule);

            _logger.LogInformation(
                $"AppointmentSchedule created  with Id {newAppointmentSchedule.AppointmentScheduleId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AppointmentScheduleDto>(newAppointmentSchedule);

            var appointmentScheduleCreatedEvent =
                new AppointmentScheduleCreatedEvent(newAppointmentSchedule, "Mongo-History");
            _messagePublisher.Publish(appointmentScheduleCreatedEvent);

            response.AppointmentSchedule = dto;


            return Ok(response);
        }
    }
}