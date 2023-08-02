using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.ConversationPayment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.ConversationPaymentEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateConversationPaymentRequest>.WithActionResult<
        UpdateConversationPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<ConversationPayment> _repository;

        public Update(
            IRepository<ConversationPayment> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/conversationPayments")]
        [SwaggerOperation(
            Summary = "Updates a ConversationPayment",
            Description = "Updates a ConversationPayment",
            OperationId = "conversationPayments.update",
            Tags = new[] { "ConversationPaymentEndpoints" })
        ]
        public override async Task<ActionResult<UpdateConversationPaymentResponse>> HandleAsync(
            UpdateConversationPaymentRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateConversationPaymentResponse(request.CorrelationId());

            var cpopnpToUpdate = _mapper.Map<ConversationPayment>(request);

            var conversationPaymentToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (conversationPaymentToUpdateTest is null)
            {
                return NotFound();
            }

            cpopnpToUpdate.UpdateConversationForConversationPayment(request.ConversationId);
            await _repository.UpdateAsync(cpopnpToUpdate);

            var conversationPaymentUpdatedEvent = new ConversationPaymentUpdatedEvent(cpopnpToUpdate, "Mongo-History");
            _messagePublisher.Publish(conversationPaymentUpdatedEvent);

            var dto = _mapper.Map<ConversationPaymentDto>(cpopnpToUpdate);
            response.ConversationPayment = dto;

            return Ok(response);
        }
    }
}