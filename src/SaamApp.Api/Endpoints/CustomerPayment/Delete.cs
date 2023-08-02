using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerPayment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerPaymentEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteCustomerPaymentRequest>.WithActionResult<
        DeleteCustomerPaymentResponse>
    {
        private readonly IRepository<CustomerPayment> _customerPaymentReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerPayment> _repository;

        public Delete(IRepository<CustomerPayment> CustomerPaymentRepository,
            IRepository<CustomerPayment> CustomerPaymentReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = CustomerPaymentRepository;
            _customerPaymentReadRepository = CustomerPaymentReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/customerPayments/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an CustomerPayment",
            Description = "Deletes an CustomerPayment",
            OperationId = "customerPayments.delete",
            Tags = new[] { "CustomerPaymentEndpoints" })
        ]
        public override async Task<ActionResult<DeleteCustomerPaymentResponse>> HandleAsync(
            [FromRoute] DeleteCustomerPaymentRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteCustomerPaymentResponse(request.CorrelationId());

            var customerPayment = await _customerPaymentReadRepository.GetByIdAsync(request.RowId);

            if (customerPayment == null)
            {
                return NotFound();
            }


            var customerPaymentDeletedEvent = new CustomerPaymentDeletedEvent(customerPayment, "Mongo-History");
            _messagePublisher.Publish(customerPaymentDeletedEvent);

            await _repository.DeleteAsync(customerPayment);

            return Ok(response);
        }
    }
}