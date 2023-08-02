using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.EmployeeAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.EmployeeAddressEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteEmployeeAddressRequest>.WithActionResult<
        DeleteEmployeeAddressResponse>
    {
        private readonly IRepository<EmployeeAddress> _employeeAddressReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<EmployeeAddress> _repository;

        public Delete(IRepository<EmployeeAddress> EmployeeAddressRepository,
            IRepository<EmployeeAddress> EmployeeAddressReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = EmployeeAddressRepository;
            _employeeAddressReadRepository = EmployeeAddressReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/employeeAddresses/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an EmployeeAddress",
            Description = "Deletes an EmployeeAddress",
            OperationId = "employeeAddresses.delete",
            Tags = new[] { "EmployeeAddressEndpoints" })
        ]
        public override async Task<ActionResult<DeleteEmployeeAddressResponse>> HandleAsync(
            [FromRoute] DeleteEmployeeAddressRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteEmployeeAddressResponse(request.CorrelationId());

            var employeeAddress = await _employeeAddressReadRepository.GetByIdAsync(request.RowId);

            if (employeeAddress == null)
            {
                return NotFound();
            }


            var employeeAddressDeletedEvent = new EmployeeAddressDeletedEvent(employeeAddress, "Mongo-History");
            _messagePublisher.Publish(employeeAddressDeletedEvent);

            await _repository.DeleteAsync(employeeAddress);

            return Ok(response);
        }
    }
}