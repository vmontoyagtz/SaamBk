using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AppointmentSchedule;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AppointmentScheduleEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListAppointmentScheduleRequest>.WithActionResult<
        ListAppointmentScheduleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AppointmentSchedule> _repository;

        public List(IRepository<AppointmentSchedule> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/appointmentSchedules")]
        [SwaggerOperation(
            Summary = "List AppointmentSchedules",
            Description = "List AppointmentSchedules",
            OperationId = "appointmentSchedules.List",
            Tags = new[] { "AppointmentScheduleEndpoints" })
        ]
        public override async Task<ActionResult<ListAppointmentScheduleResponse>> HandleAsync(
            [FromQuery] ListAppointmentScheduleRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAppointmentScheduleResponse(request.CorrelationId());

            var spec = new AppointmentScheduleGetListSpec();
            var appointmentSchedules = await _repository.ListAsync(spec);
            if (appointmentSchedules is null)
            {
                return NotFound();
            }

            response.AppointmentSchedules = _mapper.Map<List<AppointmentScheduleDto>>(appointmentSchedules);
            response.Count = response.AppointmentSchedules.Count;

            return Ok(response);
        }
    }
}