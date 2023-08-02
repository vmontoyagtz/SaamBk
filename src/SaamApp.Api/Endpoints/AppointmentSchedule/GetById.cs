using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AppointmentSchedule;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AppointmentScheduleEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAppointmentScheduleRequest>.WithActionResult<
        GetByIdAppointmentScheduleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AppointmentSchedule> _repository;

        public GetById(
            IRepository<AppointmentSchedule> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/appointmentSchedules/{AppointmentScheduleId}")]
        [SwaggerOperation(
            Summary = "Get a AppointmentSchedule by Id",
            Description = "Gets a AppointmentSchedule by Id",
            OperationId = "appointmentSchedules.GetById",
            Tags = new[] { "AppointmentScheduleEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAppointmentScheduleResponse>> HandleAsync(
            [FromRoute] GetByIdAppointmentScheduleRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAppointmentScheduleResponse(request.CorrelationId());

            var appointmentSchedule = await _repository.GetByIdAsync(request.AppointmentScheduleId);
            if (appointmentSchedule is null)
            {
                return NotFound();
            }

            response.AppointmentSchedule = _mapper.Map<AppointmentScheduleDto>(appointmentSchedule);

            return Ok(response);
        }
    }
}