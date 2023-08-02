using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListEmployeeAddressRequest>.WithActionResult<
        ListEmployeeAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<EmployeeAddress> _repository;

        public List(IRepository<EmployeeAddress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/employeeAddresses")]
        [SwaggerOperation(
            Summary = "List EmployeeAddresses",
            Description = "List EmployeeAddresses",
            OperationId = "employeeAddresses.List",
            Tags = new[] { "EmployeeAddressEndpoints" })
        ]
        public override async Task<ActionResult<ListEmployeeAddressResponse>> HandleAsync(
            [FromQuery] ListEmployeeAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListEmployeeAddressResponse(request.CorrelationId());

            var spec = new EmployeeAddressGetListSpec();
            var employeeAddresses = await _repository.ListAsync(spec);
            if (employeeAddresses is null)
            {
                return NotFound();
            }

            response.EmployeeAddresses = _mapper.Map<List<EmployeeAddressDto>>(employeeAddresses);
            response.Count = response.EmployeeAddresses.Count;

            return Ok(response);
        }
    }
}