using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Employee;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.EmployeeEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteEmployeeRequest>.WithActionResult<
        DeleteEmployeeResponse>
    {
        private readonly IRepository<EmployeeAddress> _employeeAddressRepository;
        private readonly IRepository<EmployeeEmailAddress> _employeeEmailAddressRepository;
        private readonly IRepository<EmployeePhoneNumber> _employeePhoneNumberRepository;
        private readonly IRepository<Employee> _employeeReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Employee> _repository;

        public Delete(IRepository<Employee> EmployeeRepository, IRepository<Employee> EmployeeReadRepository,
            IRepository<EmployeeAddress> employeeAddressRepository,
            IRepository<EmployeeEmailAddress> employeeEmailAddressRepository,
            IRepository<EmployeePhoneNumber> employeePhoneNumberRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = EmployeeRepository;
            _employeeReadRepository = EmployeeReadRepository;
            _employeeAddressRepository = employeeAddressRepository;
            _employeeEmailAddressRepository = employeeEmailAddressRepository;
            _employeePhoneNumberRepository = employeePhoneNumberRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/employees/{EmployeeId}")]
        [SwaggerOperation(
            Summary = "Deletes an Employee",
            Description = "Deletes an Employee",
            OperationId = "employees.delete",
            Tags = new[] { "EmployeeEndpoints" })
        ]
        public override async Task<ActionResult<DeleteEmployeeResponse>> HandleAsync(
            [FromRoute] DeleteEmployeeRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteEmployeeResponse(request.CorrelationId());

            var employee = await _employeeReadRepository.GetByIdAsync(request.EmployeeId);

            if (employee == null)
            {
                return NotFound();
            }

            var employeeAddressSpec = new GetEmployeeAddressWithEmployeeKeySpec(employee.EmployeeId);
            var employeeAddresses = await _employeeAddressRepository.ListAsync(employeeAddressSpec);
            await _employeeAddressRepository.DeleteRangeAsync(employeeAddresses);
            var employeeEmailAddressSpec = new GetEmployeeEmailAddressWithEmployeeKeySpec(employee.EmployeeId);
            var employeeEmailAddresses = await _employeeEmailAddressRepository.ListAsync(employeeEmailAddressSpec);
            await _employeeEmailAddressRepository.DeleteRangeAsync(employeeEmailAddresses);
            var employeePhoneNumberSpec = new GetEmployeePhoneNumberWithEmployeeKeySpec(employee.EmployeeId);
            var employeePhoneNumbers = await _employeePhoneNumberRepository.ListAsync(employeePhoneNumberSpec);
            await _employeePhoneNumberRepository.DeleteRangeAsync(employeePhoneNumbers);

            var employeeDeletedEvent = new EmployeeDeletedEvent(employee, "Mongo-History");
            _messagePublisher.Publish(employeeDeletedEvent);

            await _repository.DeleteAsync(employee);

            return Ok(response);
        }
    }
}