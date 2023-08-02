using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerPayment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.CustomerPaymentEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateCustomerPaymentRequest>.WithActionResult<
        UpdateCustomerPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerPayment> _repository;

        public Update(
            IRepository<CustomerPayment> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/customerPayments")]
        [SwaggerOperation(
            Summary = "Updates a CustomerPayment",
            Description = "Updates a CustomerPayment",
            OperationId = "customerPayments.update",
            Tags = new[] { "CustomerPaymentEndpoints" })
        ]
        public override async Task<ActionResult<UpdateCustomerPaymentResponse>> HandleAsync(
            UpdateCustomerPaymentRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateCustomerPaymentResponse(request.CorrelationId());

            var cpupspToUpdate = _mapper.Map<CustomerPayment>(request);

            var customerPaymentToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (customerPaymentToUpdateTest is null)
            {
                return NotFound();
            }

            cpupspToUpdate.UpdatePaymentMethodForCustomerPayment(request.PaymentMethodId);
            cpupspToUpdate.UpdateSerfinsaPaymentForCustomerPayment(request.SerfinsaPaymentId);
            await _repository.UpdateAsync(cpupspToUpdate);

            var customerPaymentUpdatedEvent = new CustomerPaymentUpdatedEvent(cpupspToUpdate, "Mongo-History");
            _messagePublisher.Publish(customerPaymentUpdatedEvent);

            var dto = _mapper.Map<CustomerPaymentDto>(cpupspToUpdate);
            response.CustomerPayment = dto;

            return Ok(response);
        }
    }
}