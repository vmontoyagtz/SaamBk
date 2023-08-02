using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.PaymentFrequency;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.PaymentFrequencyEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeletePaymentFrequencyRequest>.WithActionResult<
        DeletePaymentFrequencyResponse>
    {
        private readonly IRepository<Advisor> _advisorRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<PaymentFrequency> _paymentFrequencyReadRepository;
        private readonly IRepository<PaymentFrequency> _repository;

        public Delete(IRepository<PaymentFrequency> PaymentFrequencyRepository,
            IRepository<PaymentFrequency> PaymentFrequencyReadRepository,
            IRepository<Advisor> advisorRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = PaymentFrequencyRepository;
            _paymentFrequencyReadRepository = PaymentFrequencyReadRepository;
            _advisorRepository = advisorRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/paymentFrequencies/{PaymentFrequencyId}")]
        [SwaggerOperation(
            Summary = "Deletes an PaymentFrequency",
            Description = "Deletes an PaymentFrequency",
            OperationId = "paymentFrequencies.delete",
            Tags = new[] { "PaymentFrequencyEndpoints" })
        ]
        public override async Task<ActionResult<DeletePaymentFrequencyResponse>> HandleAsync(
            [FromRoute] DeletePaymentFrequencyRequest request, CancellationToken cancellationToken)
        {
            var response = new DeletePaymentFrequencyResponse(request.CorrelationId());

            var paymentFrequency = await _paymentFrequencyReadRepository.GetByIdAsync(request.PaymentFrequencyId);

            if (paymentFrequency == null)
            {
                return NotFound();
            }

            var advisorSpec = new GetAdvisorWithPaymentFrequencyKeySpec(paymentFrequency.PaymentFrequencyId);
            var advisors = await _advisorRepository.ListAsync(advisorSpec);
            await _advisorRepository.DeleteRangeAsync(advisors); // you could use soft delete with IsDeleted = true

            var paymentFrequencyDeletedEvent = new PaymentFrequencyDeletedEvent(paymentFrequency, "Mongo-History");
            _messagePublisher.Publish(paymentFrequencyDeletedEvent);

            await _repository.DeleteAsync(paymentFrequency);

            return Ok(response);
        }
    }
}