using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerEmailAddressEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteCustomerEmailAddressRequest>.WithActionResult<
        DeleteCustomerEmailAddressResponse>
    {
        private readonly IRepository<CustomerEmailAddress> _customerEmailAddressReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerEmailAddress> _repository;

        public Delete(IRepository<CustomerEmailAddress> CustomerEmailAddressRepository,
            IRepository<CustomerEmailAddress> CustomerEmailAddressReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = CustomerEmailAddressRepository;
            _customerEmailAddressReadRepository = CustomerEmailAddressReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/customerEmailAddresses/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an CustomerEmailAddress",
            Description = "Deletes an CustomerEmailAddress",
            OperationId = "customerEmailAddresses.delete",
            Tags = new[] { "CustomerEmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<DeleteCustomerEmailAddressResponse>> HandleAsync(
            [FromRoute] DeleteCustomerEmailAddressRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteCustomerEmailAddressResponse(request.CorrelationId());

            var customerEmailAddress = await _customerEmailAddressReadRepository.GetByIdAsync(request.RowId);

            if (customerEmailAddress == null)
            {
                return NotFound();
            }


            var customerEmailAddressDeletedEvent =
                new CustomerEmailAddressDeletedEvent(customerEmailAddress, "Mongo-History");
            _messagePublisher.Publish(customerEmailAddressDeletedEvent);

            await _repository.DeleteAsync(customerEmailAddress);

            return Ok(response);
        }
    }
}