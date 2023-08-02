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
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdAppointmentScheduleRequest>.WithActionResult
    <
        GetByIdAppointmentScheduleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AppointmentSchedule> _repository;

        public GetByIdWithIncludes(
            IRepository<AppointmentSchedule> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/appointmentSchedules/i/{AppointmentScheduleId}")]
        [SwaggerOperation(
            Summary = "Get a AppointmentSchedule by Id With Includes",
            Description = "Gets a AppointmentSchedule by Id With Includes",
            OperationId = "appointmentSchedules.GetByIdWithIncludes",
            Tags = new[] { "AppointmentScheduleEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAppointmentScheduleResponse>> HandleAsync(
            [FromRoute] GetByIdAppointmentScheduleRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAppointmentScheduleResponse(request.CorrelationId());

            var spec = new AppointmentScheduleByIdWithIncludesSpec(request.AppointmentScheduleId);

            var appointmentSchedule = await _repository.FirstOrDefaultAsync(spec);


            if (appointmentSchedule is null)
            {
                return NotFound();
            }

            response.AppointmentSchedule = _mapper.Map<AppointmentScheduleDto>(appointmentSchedule);

            return Ok(response);
        }
    }
}