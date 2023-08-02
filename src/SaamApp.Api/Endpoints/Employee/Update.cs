using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Employee;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.EmployeeEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateEmployeeRequest>.WithActionResult<UpdateEmployeeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Employee> _repository;

        public Update(
            IRepository<Employee> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/employees")]
        [SwaggerOperation(
            Summary = "Updates a Employee",
            Description = "Updates a Employee",
            OperationId = "employees.update",
            Tags = new[] { "EmployeeEndpoints" })
        ]
        public override async Task<ActionResult<UpdateEmployeeResponse>> HandleAsync(UpdateEmployeeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateEmployeeResponse(request.CorrelationId());

            var empToUpdate = _mapper.Map<Employee>(request);

            var employeeToUpdateTest = await _repository.GetByIdAsync(request.EmployeeId);
            if (employeeToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(empToUpdate);

            var employeeUpdatedEvent = new EmployeeUpdatedEvent(empToUpdate, "Mongo-History");
            _messagePublisher.Publish(employeeUpdatedEvent);

            var dto = _mapper.Map<EmployeeDto>(empToUpdate);
            response.Employee = dto;

            return Ok(response);
        }
    }
}