using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.MessageType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.MessageTypeEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteMessageTypeRequest>.WithActionResult<
        DeleteMessageTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Message> _messageRepository;
        private readonly IRepository<MessageType> _messageTypeReadRepository;
        private readonly IRepository<MessageType> _repository;

        public Delete(IRepository<MessageType> MessageTypeRepository,
            IRepository<MessageType> MessageTypeReadRepository,
            IRepository<Message> messageRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = MessageTypeRepository;
            _messageTypeReadRepository = MessageTypeReadRepository;
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/messageTypes/{MessageTypeId}")]
        [SwaggerOperation(
            Summary = "Deletes an MessageType",
            Description = "Deletes an MessageType",
            OperationId = "messageTypes.delete",
            Tags = new[] { "MessageTypeEndpoints" })
        ]
        public override async Task<ActionResult<DeleteMessageTypeResponse>> HandleAsync(
            [FromRoute] DeleteMessageTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteMessageTypeResponse(request.CorrelationId());

            var messageType = await _messageTypeReadRepository.GetByIdAsync(request.MessageTypeId);

            if (messageType == null)
            {
                return NotFound();
            }

            var messageSpec = new GetMessageWithMessageTypeKeySpec(messageType.MessageTypeId);
            var messages = await _messageRepository.ListAsync(messageSpec);
            await _messageRepository.DeleteRangeAsync(messages); // you could use soft delete with IsDeleted = true

            var messageTypeDeletedEvent = new MessageTypeDeletedEvent(messageType, "Mongo-History");
            _messagePublisher.Publish(messageTypeDeletedEvent);

            await _repository.DeleteAsync(messageType);

            return Ok(response);
        }
    }
}