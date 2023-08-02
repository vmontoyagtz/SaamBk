using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.Document;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.DocumentEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateDocumentRequest>.WithActionResult<
        CreateDocumentResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Document> _repository;

        public Create(
            IRepository<Document> repository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
        }

        [HttpPost("api/documents")]
        [SwaggerOperation(
            Summary = "Creates a new Document",
            Description = "Creates a new Document",
            OperationId = "documents.create",
            Tags = new[] { "DocumentEndpoints" })
        ]
        public override async Task<ActionResult<CreateDocumentResponse>> HandleAsync(
            CreateDocumentRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateDocumentResponse(request.CorrelationId());


            var newDocument = new Document(
                Guid.NewGuid(),
                request.DocumentUri,
                request.DocumentToken,
                request.DocumentSecuredUrl,
                request.DocumentTitle,
                request.DocumentDescription,
                request.TenantId
            );


            await _repository.AddAsync(newDocument);

            _logger.LogInformation(
                $"Document created  with Id {newDocument.DocumentId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<DocumentDto>(newDocument);

            var documentCreatedEvent = new DocumentCreatedEvent(newDocument, "Mongo-History");
            _messagePublisher.Publish(documentCreatedEvent);

            response.Document = dto;


            return Ok(response);
        }
    }
}