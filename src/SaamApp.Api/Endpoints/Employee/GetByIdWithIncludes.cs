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
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdEmployeeRequest>.WithActionResult<
        GetByIdEmployeeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Employee> _repository;

        public GetByIdWithIncludes(
            IRepository<Employee> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/employees/i/{EmployeeId}")]
        [SwaggerOperation(
            Summary = "Get a Employee by Id With Includes",
            Description = "Gets a Employee by Id With Includes",
            OperationId = "employees.GetByIdWithIncludes",
            Tags = new[] { "EmployeeEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdEmployeeResponse>> HandleAsync(
            [FromRoute] GetByIdEmployeeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdEmployeeResponse(request.CorrelationId());

            var spec = new EmployeeByIdWithIncludesSpec(request.EmployeeId);

            var employee = await _repository.FirstOrDefaultAsync(spec);


            if (employee is null)
            {
                return NotFound();
            }

            response.Employee = _mapper.Map<EmployeeDto>(employee);

            return Ok(response);
        }
    }
}