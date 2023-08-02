using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Employee;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.EmployeeEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListEmployeeRequest>.WithActionResult<ListEmployeeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Employee> _repository;

        public List(IRepository<Employee> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/employees")]
        [SwaggerOperation(
            Summary = "List Employees",
            Description = "List Employees",
            OperationId = "employees.List",
            Tags = new[] { "EmployeeEndpoints" })
        ]
        public override async Task<ActionResult<ListEmployeeResponse>> HandleAsync(
            [FromQuery] ListEmployeeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListEmployeeResponse(request.CorrelationId());

            var spec = new EmployeeGetListSpec();
            var employees = await _repository.ListAsync(spec);
            if (employees is null)
            {
                return NotFound();
            }

            response.Employees = _mapper.Map<List<EmployeeDto>>(employees);
            response.Count = response.Employees.Count;

            return Ok(response);
        }
    }
}