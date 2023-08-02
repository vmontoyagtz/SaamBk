using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.EmployeeAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.EmployeeAddressEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdEmployeeAddressRequest>.WithActionResult<
        GetByIdEmployeeAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<EmployeeAddress> _repository;

        public GetById(
            IRepository<EmployeeAddress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/employeeAddresses/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a EmployeeAddress by Id",
            Description = "Gets a EmployeeAddress by Id",
            OperationId = "employeeAddresses.GetById",
            Tags = new[] { "EmployeeAddressEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdEmployeeAddressResponse>> HandleAsync(
            [FromRoute] GetByIdEmployeeAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdEmployeeAddressResponse(request.CorrelationId());

            var employeeAddress = await _repository.GetByIdAsync(request.RowId);
            if (employeeAddress is null)
            {
                return NotFound();
            }

            response.EmployeeAddress = _mapper.Map<EmployeeAddressDto>(employeeAddress);

            return Ok(response);
        }
    }
}