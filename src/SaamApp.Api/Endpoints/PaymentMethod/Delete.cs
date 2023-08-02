using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.PaymentMethod;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.PaymentMethodEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeletePaymentMethodRequest>.WithActionResult<
        DeletePaymentMethodResponse>
    {
        private readonly IRepository<AdvisorPayment> _advisorPaymentRepository;
        private readonly IRepository<CustomerPayment> _customerPaymentRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<PaymentMethod> _paymentMethodReadRepository;
        private readonly IRepository<PaymentMethod> _repository;

        public Delete(IRepository<PaymentMethod> PaymentMethodRepository,
            IRepository<PaymentMethod> PaymentMethodReadRepository,
            IRepository<AdvisorPayment> advisorPaymentRepository,
            IRepository<CustomerPayment> customerPaymentRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = PaymentMethodRepository;
            _paymentMethodReadRepository = PaymentMethodReadRepository;
            _advisorPaymentRepository = advisorPaymentRepository;
            _customerPaymentRepository = customerPaymentRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/paymentMethods/{PaymentMethodId}")]
        [SwaggerOperation(
            Summary = "Deletes an PaymentMethod",
            Description = "Deletes an PaymentMethod",
            OperationId = "paymentMethods.delete",
            Tags = new[] { "PaymentMethodEndpoints" })
        ]
        public override async Task<ActionResult<DeletePaymentMethodResponse>> HandleAsync(
            [FromRoute] DeletePaymentMethodRequest request, CancellationToken cancellationToken)
        {
            var response = new DeletePaymentMethodResponse(request.CorrelationId());

            var paymentMethod = await _paymentMethodReadRepository.GetByIdAsync(request.PaymentMethodId);

            if (paymentMethod == null)
            {
                return NotFound();
            }

            var advisorPaymentSpec = new GetAdvisorPaymentWithPaymentMethodKeySpec(paymentMethod.PaymentMethodId);
            var advisorPayments = await _advisorPaymentRepository.ListAsync(advisorPaymentSpec);
            await _advisorPaymentRepository.DeleteRangeAsync(advisorPayments);
            var customerPaymentSpec = new GetCustomerPaymentWithPaymentMethodKeySpec(paymentMethod.PaymentMethodId);
            var customerPayments = await _customerPaymentRepository.ListAsync(customerPaymentSpec);
            await _customerPaymentRepository.DeleteRangeAsync(customerPayments);

            var paymentMethodDeletedEvent = new PaymentMethodDeletedEvent(paymentMethod, "Mongo-History");
            _messagePublisher.Publish(paymentMethodDeletedEvent);

            await _repository.DeleteAsync(paymentMethod);

            return Ok(response);
        }
    }
}