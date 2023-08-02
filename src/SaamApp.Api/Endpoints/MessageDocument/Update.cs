using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.MessageDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.MessageDocumentEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateMessageDocumentRequest>.WithActionResult<
        UpdateMessageDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<MessageDocument> _repository;

        public Update(
            IRepository<MessageDocument> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/messageDocuments")]
        [SwaggerOperation(
            Summary = "Updates a MessageDocument",
            Description = "Updates a MessageDocument",
            OperationId = "messageDocuments.update",
            Tags = new[] { "MessageDocumentEndpoints" })
        ]
        public override async Task<ActionResult<UpdateMessageDocumentResponse>> HandleAsync(
            UpdateMessageDocumentRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateMessageDocumentResponse(request.CorrelationId());

            var mdedsdToUpdate = _mapper.Map<MessageDocument>(request);

            var messageDocumentToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (messageDocumentToUpdateTest is null)
            {
                return NotFound();
            }

            //mdedsdToUpdate.UpdateDocumentForMessageDocument(request.DocumentId);
            //mdedsdToUpdate.UpdateDocumentTypeForMessageDocument(request.DocumentTypeId);
            //mdedsdToUpdate.UpdateMessageForMessageDocument(request.MessageId);
            await _repository.UpdateAsync(mdedsdToUpdate);

            var messageDocumentUpdatedEvent = new MessageDocumentUpdatedEvent(mdedsdToUpdate, "Mongo-History");
            _messagePublisher.Publish(messageDocumentUpdatedEvent);

            var dto = _mapper.Map<MessageDocumentDto>(mdedsdToUpdate);
            response.MessageDocument = dto;

            return Ok(response);
        }
    }
}