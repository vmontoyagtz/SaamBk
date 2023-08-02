using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Message;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.MessageEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteMessageRequest>.WithActionResult<
        DeleteMessageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<MessageDocument> _messageDocumentRepository;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Message> _messageReadRepository;
        private readonly IRepository<Message> _repository;
        private readonly IRepository<VoiceNoteDocument> _voiceNoteDocumentRepository;

        public Delete(IRepository<Message> MessageRepository, IRepository<Message> MessageReadRepository,
            IRepository<MessageDocument> messageDocumentRepository,
            IRepository<VoiceNoteDocument> voiceNoteDocumentRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = MessageRepository;
            _messageReadRepository = MessageReadRepository;
            _messageDocumentRepository = messageDocumentRepository;
            _voiceNoteDocumentRepository = voiceNoteDocumentRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/messages/{MessageId}")]
        [SwaggerOperation(
            Summary = "Deletes an Message",
            Description = "Deletes an Message",
            OperationId = "messages.delete",
            Tags = new[] { "MessageEndpoints" })
        ]
        public override async Task<ActionResult<DeleteMessageResponse>> HandleAsync(
            [FromRoute] DeleteMessageRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteMessageResponse(request.CorrelationId());

            var message = await _messageReadRepository.GetByIdAsync(request.MessageId);

            if (message == null)
            {
                return NotFound();
            }

            var messageDocumentSpec = new GetMessageDocumentWithMessageKeySpec(message.MessageId);
            var messageDocuments = await _messageDocumentRepository.ListAsync(messageDocumentSpec);
            await _messageDocumentRepository.DeleteRangeAsync(messageDocuments);
            var voiceNoteDocumentSpec = new GetVoiceNoteDocumentWithMessageKeySpec(message.MessageId);
            var voiceNoteDocuments = await _voiceNoteDocumentRepository.ListAsync(voiceNoteDocumentSpec);
            await _voiceNoteDocumentRepository.DeleteRangeAsync(voiceNoteDocuments);

            var messageDeletedEvent = new MessageDeletedEvent(message, "Mongo-History");
            _messagePublisher.Publish(messageDeletedEvent);

            await _repository.DeleteAsync(message);

            return Ok(response);
        }
    }
}