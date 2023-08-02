using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.EmployeePhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.EmployeePhoneNumberEndpoints
{
    public class GetByRelsIds : EndpointBaseAsync.WithRequest<GetByRelsIdsEmployeePhoneNumberRequest>.WithActionResult<
        GetByIdEmployeePhoneNumberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<EmployeePhoneNumber> _repository;

        public GetByRelsIds(
            IRepository<EmployeePhoneNumber> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/employeePhoneNumbers/{EmployeeId}/{PhoneNumberId}")]
        [SwaggerOperation(
            Summary = "Get a EmployeePhoneNumber by rel Ids",
            Description = "Gets a EmployeePhoneNumber by rel Ids",
            OperationId = "employeePhoneNumbers.GetByRelsIds",
            Tags = new[] { "EmployeePhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdEmployeePhoneNumberResponse>> HandleAsync(
            [FromRoute] GetByRelsIdsEmployeePhoneNumberRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdEmployeePhoneNumberResponse(request.CorrelationId());

            var spec = new EmployeePhoneNumberByRelIdsSpec(request.EmployeeId, request.PhoneNumberId);

            var employeePhoneNumber = await _repository.FirstOrDefaultAsync(spec);


            if (employeePhoneNumber is null)
            {
                return NotFound();
            }

            response.EmployeePhoneNumber = _mapper.Map<EmployeePhoneNumberDto>(employeePhoneNumber);

            return Ok(response);
        }
    }
}