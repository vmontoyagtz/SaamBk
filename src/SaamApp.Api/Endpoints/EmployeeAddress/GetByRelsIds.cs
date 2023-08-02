using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.EmployeeAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.EmployeeAddressEndpoints
{
    public class GetByRelsIds : EndpointBaseAsync.WithRequest<GetByRelsIdsEmployeeAddressRequest>.WithActionResult<
        GetByIdEmployeeAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<EmployeeAddress> _repository;

        public GetByRelsIds(
            IRepository<EmployeeAddress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/employeeAddresses/{AddressId}/{EmployeeId}")]
        [SwaggerOperation(
            Summary = "Get a EmployeeAddress by rel Ids",
            Description = "Gets a EmployeeAddress by rel Ids",
            OperationId = "employeeAddresses.GetByRelsIds",
            Tags = new[] { "EmployeeAddressEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdEmployeeAddressResponse>> HandleAsync(
            [FromRoute] GetByRelsIdsEmployeeAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdEmployeeAddressResponse(request.CorrelationId());

            var spec = new EmployeeAddressByRelIdsSpec(request.AddressId, request.EmployeeId);

            var employeeAddress = await _repository.FirstOrDefaultAsync(spec);


            if (employeeAddress is null)
            {
                return NotFound();
            }

            response.EmployeeAddress = _mapper.Map<EmployeeAddressDto>(employeeAddress);

            return Ok(response);
        }
    }
}