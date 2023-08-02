using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.SerfinsaPayment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.SerfinsaPaymentEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteSerfinsaPaymentRequest>.WithActionResult<
        DeleteSerfinsaPaymentResponse>
    {
        private readonly IRepository<CustomerPayment> _customerPaymentRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<SerfinsaPayment> _repository;
        private readonly IRepository<SerfinsaPayment> _serfinsaPaymentReadRepository;

        public Delete(IRepository<SerfinsaPayment> SerfinsaPaymentRepository,
            IRepository<SerfinsaPayment> SerfinsaPaymentReadRepository,
            IRepository<CustomerPayment> customerPaymentRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = SerfinsaPaymentRepository;
            _serfinsaPaymentReadRepository = SerfinsaPaymentReadRepository;
            _customerPaymentRepository = customerPaymentRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/serfinsaPayments/{SerfinsaPaymentId}")]
        [SwaggerOperation(
            Summary = "Deletes an SerfinsaPayment",
            Description = "Deletes an SerfinsaPayment",
            OperationId = "serfinsaPayments.delete",
            Tags = new[] { "SerfinsaPaymentEndpoints" })
        ]
        public override async Task<ActionResult<DeleteSerfinsaPaymentResponse>> HandleAsync(
            [FromRoute] DeleteSerfinsaPaymentRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteSerfinsaPaymentResponse(request.CorrelationId());

            var serfinsaPayment = await _serfinsaPaymentReadRepository.GetByIdAsync(request.SerfinsaPaymentId);

            if (serfinsaPayment == null)
            {
                return NotFound();
            }

            var customerPaymentSpec =
                new GetCustomerPaymentWithSerfinsaPaymentKeySpec(serfinsaPayment.SerfinsaPaymentId);
            var customerPayments = await _customerPaymentRepository.ListAsync(customerPaymentSpec);
            await _customerPaymentRepository.DeleteRangeAsync(customerPayments);

            var serfinsaPaymentDeletedEvent = new SerfinsaPaymentDeletedEvent(serfinsaPayment, "Mongo-History");
            _messagePublisher.Publish(serfinsaPaymentDeletedEvent);

            await _repository.DeleteAsync(serfinsaPayment);

            return Ok(response);
        }
    }
}