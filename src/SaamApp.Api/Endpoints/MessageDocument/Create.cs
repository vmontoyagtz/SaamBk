using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.MessageDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.MessageDocumentEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateMessageDocumentRequest>.WithActionResult<
        CreateMessageDocumentResponse>
    {
        private readonly IRepository<Document> _documentRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<MessageDocument> _repository;

        public Create(
            IRepository<MessageDocument> repository,
            IRepository<Document> documentRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _documentRepository = documentRepository;
        }

        [HttpPost("api/messageDocuments")]
        [SwaggerOperation(
            Summary = "Creates a new MessageDocument",
            Description = "Creates a new MessageDocument",
            OperationId = "messageDocuments.create",
            Tags = new[] { "MessageDocumentEndpoints" })
        ]
        public override async Task<ActionResult<CreateMessageDocumentResponse>> HandleAsync(
            CreateMessageDocumentRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateMessageDocumentResponse(request.CorrelationId());

            //var document = await _documentRepository.GetByIdAsync(request.DocumentId);// parent entity

            var newMessageDocument = new MessageDocument(
                request.DocumentId,
                request.DocumentTypeId,
                request.MessageId,
                request.TenantId
            );


            await _repository.AddAsync(newMessageDocument);

            _logger.LogInformation(
                $"MessageDocument created  with Id {newMessageDocument.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<MessageDocumentDto>(newMessageDocument);

            var messageDocumentCreatedEvent = new MessageDocumentCreatedEvent(newMessageDocument, "Mongo-History");
            _messagePublisher.Publish(messageDocumentCreatedEvent);

            response.MessageDocument = dto;


            return Ok(response);
        }
    }
}