using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerPurchase;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.CustomerPurchaseEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateCustomerPurchaseRequest>.WithActionResult<
        UpdateCustomerPurchaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerPurchase> _repository;

        public Update(
            IRepository<CustomerPurchase> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/customerPurchases")]
        [SwaggerOperation(
            Summary = "Updates a CustomerPurchase",
            Description = "Updates a CustomerPurchase",
            OperationId = "customerPurchases.update",
            Tags = new[] { "CustomerPurchaseEndpoints" })
        ]
        public override async Task<ActionResult<UpdateCustomerPurchaseResponse>> HandleAsync(
            UpdateCustomerPurchaseRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateCustomerPurchaseResponse(request.CorrelationId());

            var cpupspToUpdate = _mapper.Map<CustomerPurchase>(request);

            var customerPurchaseToUpdateTest = await _repository.GetByIdAsync(request.CustomerPurchaseId);
            if (customerPurchaseToUpdateTest is null)
            {
                return NotFound();
            }

            cpupspToUpdate.UpdateCustomerForCustomerPurchase(request.CustomerId);
            await _repository.UpdateAsync(cpupspToUpdate);

            var customerPurchaseUpdatedEvent = new CustomerPurchaseUpdatedEvent(cpupspToUpdate, "Mongo-History");
            _messagePublisher.Publish(customerPurchaseUpdatedEvent);

            var dto = _mapper.Map<CustomerPurchaseDto>(cpupspToUpdate);
            response.CustomerPurchase = dto;

            return Ok(response);
        }
    }
}