using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorPayment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorPaymentEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAdvisorPaymentRequest>.WithActionResult<
        DeleteAdvisorPaymentResponse>
    {
        private readonly IRepository<AdvisorPayment> _advisorPaymentReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorPayment> _repository;

        public Delete(IRepository<AdvisorPayment> AdvisorPaymentRepository,
            IRepository<AdvisorPayment> AdvisorPaymentReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AdvisorPaymentRepository;
            _advisorPaymentReadRepository = AdvisorPaymentReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/advisorPayments/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an AdvisorPayment",
            Description = "Deletes an AdvisorPayment",
            OperationId = "advisorPayments.delete",
            Tags = new[] { "AdvisorPaymentEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAdvisorPaymentResponse>> HandleAsync(
            [FromRoute] DeleteAdvisorPaymentRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAdvisorPaymentResponse(request.CorrelationId());

            var advisorPayment = await _advisorPaymentReadRepository.GetByIdAsync(request.RowId);

            if (advisorPayment == null)
            {
                return NotFound();
            }


            var advisorPaymentDeletedEvent = new AdvisorPaymentDeletedEvent(advisorPayment, "Mongo-History");
            _messagePublisher.Publish(advisorPaymentDeletedEvent);

            await _repository.DeleteAsync(advisorPayment);

            return Ok(response);
        }
    }
}