using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerPurchase;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerPurchaseEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteCustomerPurchaseRequest>.WithActionResult<
        DeleteCustomerPurchaseResponse>
    {
        private readonly IRepository<CustomerPurchase> _customerPurchaseReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerPurchase> _repository;

        public Delete(IRepository<CustomerPurchase> CustomerPurchaseRepository,
            IRepository<CustomerPurchase> CustomerPurchaseReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = CustomerPurchaseRepository;
            _customerPurchaseReadRepository = CustomerPurchaseReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/customerPurchases/{CustomerPurchaseId}")]
        [SwaggerOperation(
            Summary = "Deletes an CustomerPurchase",
            Description = "Deletes an CustomerPurchase",
            OperationId = "customerPurchases.delete",
            Tags = new[] { "CustomerPurchaseEndpoints" })
        ]
        public override async Task<ActionResult<DeleteCustomerPurchaseResponse>> HandleAsync(
            [FromRoute] DeleteCustomerPurchaseRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteCustomerPurchaseResponse(request.CorrelationId());

            var customerPurchase = await _customerPurchaseReadRepository.GetByIdAsync(request.CustomerPurchaseId);

            if (customerPurchase == null)
            {
                return NotFound();
            }


            var customerPurchaseDeletedEvent = new CustomerPurchaseDeletedEvent(customerPurchase, "Mongo-History");
            _messagePublisher.Publish(customerPurchaseDeletedEvent);

            await _repository.DeleteAsync(customerPurchase);

            return Ok(response);
        }
    }
}