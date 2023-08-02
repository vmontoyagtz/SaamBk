using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Employee;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.EmployeeEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdEmployeeRequest>.WithActionResult<
        GetByIdEmployeeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Employee> _repository;

        public GetById(
            IRepository<Employee> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/employees/{EmployeeId}")]
        [SwaggerOperation(
            Summary = "Get a Employee by Id",
            Description = "Gets a Employee by Id",
            OperationId = "employees.GetById",
            Tags = new[] { "EmployeeEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdEmployeeResponse>> HandleAsync(
            [FromRoute] GetByIdEmployeeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdEmployeeResponse(request.CorrelationId());

            var employee = await _repository.GetByIdAsync(request.EmployeeId);
            if (employee is null)
            {
                return NotFound();
            }

            response.Employee = _mapper.Map<EmployeeDto>(employee);

            return Ok(response);
        }
    }
}