using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerAddressEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteCustomerAddressRequest>.WithActionResult<
        DeleteCustomerAddressResponse>
    {
        private readonly IRepository<CustomerAddress> _customerAddressReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerAddress> _repository;

        public Delete(IRepository<CustomerAddress> CustomerAddressRepository,
            IRepository<CustomerAddress> CustomerAddressReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = CustomerAddressRepository;
            _customerAddressReadRepository = CustomerAddressReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/customerAddresses/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an CustomerAddress",
            Description = "Deletes an CustomerAddress",
            OperationId = "customerAddresses.delete",
            Tags = new[] { "CustomerAddressEndpoints" })
        ]
        public override async Task<ActionResult<DeleteCustomerAddressResponse>> HandleAsync(
            [FromRoute] DeleteCustomerAddressRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteCustomerAddressResponse(request.CorrelationId());

            var customerAddress = await _customerAddressReadRepository.GetByIdAsync(request.RowId);

            if (customerAddress == null)
            {
                return NotFound();
            }


            var customerAddressDeletedEvent = new CustomerAddressDeletedEvent(customerAddress, "Mongo-History");
            _messagePublisher.Publish(customerAddressDeletedEvent);

            await _repository.DeleteAsync(customerAddress);

            return Ok(response);
        }
    }
}