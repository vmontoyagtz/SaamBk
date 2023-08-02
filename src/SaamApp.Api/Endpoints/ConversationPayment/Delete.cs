using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.ConversationPayment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ConversationPaymentEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteConversationPaymentRequest>.WithActionResult<
        DeleteConversationPaymentResponse>
    {
        private readonly IRepository<ConversationPayment> _conversationPaymentReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<ConversationPayment> _repository;

        public Delete(IRepository<ConversationPayment> ConversationPaymentRepository,
            IRepository<ConversationPayment> ConversationPaymentReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = ConversationPaymentRepository;
            _conversationPaymentReadRepository = ConversationPaymentReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/conversationPayments/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an ConversationPayment",
            Description = "Deletes an ConversationPayment",
            OperationId = "conversationPayments.delete",
            Tags = new[] { "ConversationPaymentEndpoints" })
        ]
        public override async Task<ActionResult<DeleteConversationPaymentResponse>> HandleAsync(
            [FromRoute] DeleteConversationPaymentRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteConversationPaymentResponse(request.CorrelationId());

            var conversationPayment = await _conversationPaymentReadRepository.GetByIdAsync(request.RowId);

            if (conversationPayment == null)
            {
                return NotFound();
            }


            var conversationPaymentDeletedEvent =
                new ConversationPaymentDeletedEvent(conversationPayment, "Mongo-History");
            _messagePublisher.Publish(conversationPaymentDeletedEvent);

            await _repository.DeleteAsync(conversationPayment);

            return Ok(response);
        }
    }
}