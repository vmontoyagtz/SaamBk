using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListEmployeeEmailAddressRequest>.WithActionResult<
        ListEmployeeEmailAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<EmployeeEmailAddress> _repository;

        public List(IRepository<EmployeeEmailAddress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/employeeEmailAddresses")]
        [SwaggerOperation(
            Summary = "List EmployeeEmailAddresses",
            Description = "List EmployeeEmailAddresses",
            OperationId = "employeeEmailAddresses.List",
            Tags = new[] { "EmployeeEmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<ListEmployeeEmailAddressResponse>> HandleAsync(
            [FromQuery] ListEmployeeEmailAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListEmployeeEmailAddressResponse(request.CorrelationId());

            var spec = new EmployeeEmailAddressGetListSpec();
            var employeeEmailAddresses = await _repository.ListAsync(spec);
            if (employeeEmailAddresses is null)
            {
                return NotFound();
            }

            response.EmployeeEmailAddresses = _mapper.Map<List<EmployeeEmailAddressDto>>(employeeEmailAddresses);
            response.Count = response.EmployeeEmailAddresses.Count;

            return Ok(response);
        }
    }
}