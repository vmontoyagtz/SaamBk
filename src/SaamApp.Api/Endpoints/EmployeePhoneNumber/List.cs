using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListEmployeePhoneNumberRequest>.WithActionResult<
        ListEmployeePhoneNumberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<EmployeePhoneNumber> _repository;

        public List(IRepository<EmployeePhoneNumber> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/employeePhoneNumbers")]
        [SwaggerOperation(
            Summary = "List EmployeePhoneNumbers",
            Description = "List EmployeePhoneNumbers",
            OperationId = "employeePhoneNumbers.List",
            Tags = new[] { "EmployeePhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<ListEmployeePhoneNumberResponse>> HandleAsync(
            [FromQuery] ListEmployeePhoneNumberRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListEmployeePhoneNumberResponse(request.CorrelationId());

            var spec = new EmployeePhoneNumberGetListSpec();
            var employeePhoneNumbers = await _repository.ListAsync(spec);
            if (employeePhoneNumbers is null)
            {
                return NotFound();
            }

            response.EmployeePhoneNumbers = _mapper.Map<List<EmployeePhoneNumberDto>>(employeePhoneNumbers);
            response.Count = response.EmployeePhoneNumbers.Count;

            return Ok(response);
        }
    }
}