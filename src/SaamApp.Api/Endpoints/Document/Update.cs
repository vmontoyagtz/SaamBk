using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Document;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.DocumentEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateDocumentRequest>.WithActionResult<UpdateDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Document> _repository;

        public Update(
            IRepository<Document> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/documents")]
        [SwaggerOperation(
            Summary = "Updates a Document",
            Description = "Updates a Document",
            OperationId = "documents.update",
            Tags = new[] { "DocumentEndpoints" })
        ]
        public override async Task<ActionResult<UpdateDocumentResponse>> HandleAsync(UpdateDocumentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateDocumentResponse(request.CorrelationId());

            var docToUpdate = _mapper.Map<Document>(request);

            var documentToUpdateTest = await _repository.GetByIdAsync(request.DocumentId);
            if (documentToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(docToUpdate);

            var documentUpdatedEvent = new DocumentUpdatedEvent(docToUpdate, "Mongo-History");
            _messagePublisher.Publish(documentUpdatedEvent);

            var dto = _mapper.Map<DocumentDto>(docToUpdate);
            response.Document = dto;

            return Ok(response);
        }
    }
}