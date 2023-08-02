using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.Employee;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.EmployeeEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateEmployeeRequest>.WithActionResult<
        CreateEmployeeResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Employee> _repository;

        public Create(
            IRepository<Employee> repository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
        }

        [HttpPost("api/employees")]
        [SwaggerOperation(
            Summary = "Creates a new Employee",
            Description = "Creates a new Employee",
            OperationId = "employees.create",
            Tags = new[] { "EmployeeEndpoints" })
        ]
        public override async Task<ActionResult<CreateEmployeeResponse>> HandleAsync(
            CreateEmployeeRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateEmployeeResponse(request.CorrelationId());


            var newEmployee = new Employee(
                Guid.NewGuid(),
                request.EmployeeFirstName,
                request.EmployeeLastName,
                request.EmployeeNumber,
                request.EmployeeJobTitle,
                request.EmployeeHireDate,
                request.IsActive,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted,
                request.TenantId
            );


            await _repository.AddAsync(newEmployee);

            _logger.LogInformation(
                $"Employee created  with Id {newEmployee.EmployeeId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<EmployeeDto>(newEmployee);

            var employeeCreatedEvent = new EmployeeCreatedEvent(newEmployee, "Mongo-History");
            _messagePublisher.Publish(employeeCreatedEvent);

            response.Employee = dto;


            return Ok(response);
        }
    }
}