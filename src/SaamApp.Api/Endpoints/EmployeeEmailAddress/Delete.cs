using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.EmployeeEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.EmployeeEmailAddressEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteEmployeeEmailAddressRequest>.WithActionResult<
        DeleteEmployeeEmailAddressResponse>
    {
        private readonly IRepository<EmployeeEmailAddress> _employeeEmailAddressReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<EmployeeEmailAddress> _repository;

        public Delete(IRepository<EmployeeEmailAddress> EmployeeEmailAddressRepository,
            IRepository<EmployeeEmailAddress> EmployeeEmailAddressReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = EmployeeEmailAddressRepository;
            _employeeEmailAddressReadRepository = EmployeeEmailAddressReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/employeeEmailAddresses/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an EmployeeEmailAddress",
            Description = "Deletes an EmployeeEmailAddress",
            OperationId = "employeeEmailAddresses.delete",
            Tags = new[] { "EmployeeEmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<DeleteEmployeeEmailAddressResponse>> HandleAsync(
            [FromRoute] DeleteEmployeeEmailAddressRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteEmployeeEmailAddressResponse(request.CorrelationId());

            var employeeEmailAddress = await _employeeEmailAddressReadRepository.GetByIdAsync(request.RowId);

            if (employeeEmailAddress == null)
            {
                return NotFound();
            }


            var employeeEmailAddressDeletedEvent =
                new EmployeeEmailAddressDeletedEvent(employeeEmailAddress, "Mongo-History");
            _messagePublisher.Publish(employeeEmailAddressDeletedEvent);

            await _repository.DeleteAsync(employeeEmailAddress);

            return Ok(response);
        }
    }
}