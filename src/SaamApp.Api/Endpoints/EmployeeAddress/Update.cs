using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.EmployeeAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.EmployeeAddressEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateEmployeeAddressRequest>.WithActionResult<
        UpdateEmployeeAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<EmployeeAddress> _repository;

        public Update(
            IRepository<EmployeeAddress> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/employeeAddresses")]
        [SwaggerOperation(
            Summary = "Updates a EmployeeAddress",
            Description = "Updates a EmployeeAddress",
            OperationId = "employeeAddresses.update",
            Tags = new[] { "EmployeeAddressEndpoints" })
        ]
        public override async Task<ActionResult<UpdateEmployeeAddressResponse>> HandleAsync(
            UpdateEmployeeAddressRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateEmployeeAddressResponse(request.CorrelationId());

            var eamapaToUpdate = _mapper.Map<EmployeeAddress>(request);

            var employeeAddressToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (employeeAddressToUpdateTest is null)
            {
                return NotFound();
            }

            eamapaToUpdate.UpdateAddressForEmployeeAddress(request.AddressId);
            eamapaToUpdate.UpdateAddressTypeForEmployeeAddress(request.AddressTypeId);
            eamapaToUpdate.UpdateEmployeeForEmployeeAddress(request.EmployeeId);
            await _repository.UpdateAsync(eamapaToUpdate);

            var employeeAddressUpdatedEvent = new EmployeeAddressUpdatedEvent(eamapaToUpdate, "Mongo-History");
            _messagePublisher.Publish(employeeAddressUpdatedEvent);

            var dto = _mapper.Map<EmployeeAddressDto>(eamapaToUpdate);
            response.EmployeeAddress = dto;

            return Ok(response);
        }
    }
}