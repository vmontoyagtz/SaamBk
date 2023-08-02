using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.EmployeeEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.EmployeeEmailAddressEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdEmployeeEmailAddressRequest>.WithActionResult<
        GetByIdEmployeeEmailAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<EmployeeEmailAddress> _repository;

        public GetById(
            IRepository<EmployeeEmailAddress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/employeeEmailAddresses/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a EmployeeEmailAddress by Id",
            Description = "Gets a EmployeeEmailAddress by Id",
            OperationId = "employeeEmailAddresses.GetById",
            Tags = new[] { "EmployeeEmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdEmployeeEmailAddressResponse>> HandleAsync(
            [FromRoute] GetByIdEmployeeEmailAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdEmployeeEmailAddressResponse(request.CorrelationId());

            var employeeEmailAddress = await _repository.GetByIdAsync(request.RowId);
            if (employeeEmailAddress is null)
            {
                return NotFound();
            }

            response.EmployeeEmailAddress = _mapper.Map<EmployeeEmailAddressDto>(employeeEmailAddress);

            return Ok(response);
        }
    }
}