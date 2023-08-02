using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.CustomerAddressEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateCustomerAddressRequest>.WithActionResult<
        UpdateCustomerAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerAddress> _repository;

        public Update(
            IRepository<CustomerAddress> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/customerAddresses")]
        [SwaggerOperation(
            Summary = "Updates a CustomerAddress",
            Description = "Updates a CustomerAddress",
            OperationId = "customerAddresses.update",
            Tags = new[] { "CustomerAddressEndpoints" })
        ]
        public override async Task<ActionResult<UpdateCustomerAddressResponse>> HandleAsync(
            UpdateCustomerAddressRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateCustomerAddressResponse(request.CorrelationId());

            var cauasaToUpdate = _mapper.Map<CustomerAddress>(request);

            var customerAddressToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (customerAddressToUpdateTest is null)
            {
                return NotFound();
            }

            cauasaToUpdate.UpdateAddressForCustomerAddress(request.AddressId);
            cauasaToUpdate.UpdateAddressTypeForCustomerAddress(request.AddressTypeId);
            cauasaToUpdate.UpdateCustomerForCustomerAddress(request.CustomerId);
            await _repository.UpdateAsync(cauasaToUpdate);

            var customerAddressUpdatedEvent = new CustomerAddressUpdatedEvent(cauasaToUpdate, "Mongo-History");
            _messagePublisher.Publish(customerAddressUpdatedEvent);

            var dto = _mapper.Map<CustomerAddressDto>(cauasaToUpdate);
            response.CustomerAddress = dto;

            return Ok(response);
        }
    }
}