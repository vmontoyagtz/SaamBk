using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Message;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.MessageEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateMessageRequest>.WithActionResult<UpdateMessageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Message> _repository;

        public Update(
            IRepository<Message> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/messages")]
        [SwaggerOperation(
            Summary = "Updates a Message",
            Description = "Updates a Message",
            OperationId = "messages.update",
            Tags = new[] { "MessageEndpoints" })
        ]
        public override async Task<ActionResult<UpdateMessageResponse>> HandleAsync(UpdateMessageRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateMessageResponse(request.CorrelationId());

            var mesToUpdate = _mapper.Map<Message>(request);

            var messageToUpdateTest = await _repository.GetByIdAsync(request.MessageId);
            if (messageToUpdateTest is null)
            {
                return NotFound();
            }

            //mesToUpdate.UpdateRegionAreaAdvisorCategoryForMessage(request.RegionAreaAdvisorCategoryId);
            //mesToUpdate.UpdateAdvisorForMessage(request.AdvisorId);
            //mesToUpdate.UpdateConversationForMessage(request.ConversationId);
            //mesToUpdate.UpdateCustomerForMessage(request.CustomerId);
            //mesToUpdate.UpdateInteractionTypeForMessage(request.InteractionTypeId);
            //mesToUpdate.UpdateMessageTypeForMessage(request.MessageTypeId);
            //mesToUpdate.UpdateProductForMessage(request.ProductId);
            await _repository.UpdateAsync(mesToUpdate);

            var messageUpdatedEvent = new MessageUpdatedEvent(mesToUpdate, "Mongo-History");
            _messagePublisher.Publish(messageUpdatedEvent);

            var dto = _mapper.Map<MessageDto>(mesToUpdate);
            response.Message = dto;

            return Ok(response);
        }
    }
}