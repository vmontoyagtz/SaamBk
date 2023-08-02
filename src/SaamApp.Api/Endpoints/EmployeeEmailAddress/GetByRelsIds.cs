using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.EmployeeEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.EmployeeEmailAddressEndpoints
{
    public class GetByRelsIds : EndpointBaseAsync.WithRequest<GetByRelsIdsEmployeeEmailAddressRequest>.WithActionResult<
        GetByIdEmployeeEmailAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<EmployeeEmailAddress> _repository;

        public GetByRelsIds(
            IRepository<EmployeeEmailAddress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/employeeEmailAddresses/{EmailAddressId}/{EmployeeId}")]
        [SwaggerOperation(
            Summary = "Get a EmployeeEmailAddress by rel Ids",
            Description = "Gets a EmployeeEmailAddress by rel Ids",
            OperationId = "employeeEmailAddresses.GetByRelsIds",
            Tags = new[] { "EmployeeEmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdEmployeeEmailAddressResponse>> HandleAsync(
            [FromRoute] GetByRelsIdsEmployeeEmailAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdEmployeeEmailAddressResponse(request.CorrelationId());

            var spec = new EmployeeEmailAddressByRelIdsSpec(request.EmailAddressId, request.EmployeeId);

            var employeeEmailAddress = await _repository.FirstOrDefaultAsync(spec);


            if (employeeEmailAddress is null)
            {
                return NotFound();
            }

            response.EmployeeEmailAddress = _mapper.Map<EmployeeEmailAddressDto>(employeeEmailAddress);

            return Ok(response);
        }
    }
}