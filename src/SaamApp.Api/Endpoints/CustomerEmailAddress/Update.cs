using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.CustomerEmailAddressEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateCustomerEmailAddressRequest>.WithActionResult<
        UpdateCustomerEmailAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerEmailAddress> _repository;

        public Update(
            IRepository<CustomerEmailAddress> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/customerEmailAddresses")]
        [SwaggerOperation(
            Summary = "Updates a CustomerEmailAddress",
            Description = "Updates a CustomerEmailAddress",
            OperationId = "customerEmailAddresses.update",
            Tags = new[] { "CustomerEmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<UpdateCustomerEmailAddressResponse>> HandleAsync(
            UpdateCustomerEmailAddressRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateCustomerEmailAddressResponse(request.CorrelationId());

            var ceaueaseaToUpdate = _mapper.Map<CustomerEmailAddress>(request);

            var customerEmailAddressToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (customerEmailAddressToUpdateTest is null)
            {
                return NotFound();
            }

            ceaueaseaToUpdate.UpdateCustomerForCustomerEmailAddress(request.CustomerId);
            ceaueaseaToUpdate.UpdateEmailAddressForCustomerEmailAddress(request.EmailAddressId);
            ceaueaseaToUpdate.UpdateEmailAddressTypeForCustomerEmailAddress(request.EmailAddressTypeId);
            await _repository.UpdateAsync(ceaueaseaToUpdate);

            var customerEmailAddressUpdatedEvent =
                new CustomerEmailAddressUpdatedEvent(ceaueaseaToUpdate, "Mongo-History");
            _messagePublisher.Publish(customerEmailAddressUpdatedEvent);

            var dto = _mapper.Map<CustomerEmailAddressDto>(ceaueaseaToUpdate);
            response.CustomerEmailAddress = dto;

            return Ok(response);
        }
    }
}