using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.MessageDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.MessageDocumentEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteMessageDocumentRequest>.WithActionResult<
        DeleteMessageDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<MessageDocument> _messageDocumentReadRepository;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<MessageDocument> _repository;

        public Delete(IRepository<MessageDocument> MessageDocumentRepository,
            IRepository<MessageDocument> MessageDocumentReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = MessageDocumentRepository;
            _messageDocumentReadRepository = MessageDocumentReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/messageDocuments/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an MessageDocument",
            Description = "Deletes an MessageDocument",
            OperationId = "messageDocuments.delete",
            Tags = new[] { "MessageDocumentEndpoints" })
        ]
        public override async Task<ActionResult<DeleteMessageDocumentResponse>> HandleAsync(
            [FromRoute] DeleteMessageDocumentRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteMessageDocumentResponse(request.CorrelationId());

            var messageDocument = await _messageDocumentReadRepository.GetByIdAsync(request.RowId);

            if (messageDocument == null)
            {
                return NotFound();
            }


            var messageDocumentDeletedEvent = new MessageDocumentDeletedEvent(messageDocument, "Mongo-History");
            _messagePublisher.Publish(messageDocumentDeletedEvent);

            await _repository.DeleteAsync(messageDocument);

            return Ok(response);
        }
    }
}