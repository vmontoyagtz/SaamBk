using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.TemplateDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TemplateDocumentEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateTemplateDocumentRequest>.WithActionResult<
        CreateTemplateDocumentResponse>
    {
        private readonly IRepository<Document> _documentRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TemplateDocument> _repository;

        public Create(
            IRepository<TemplateDocument> repository,
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

        [HttpPost("api/templateDocuments")]
        [SwaggerOperation(
            Summary = "Creates a new TemplateDocument",
            Description = "Creates a new TemplateDocument",
            OperationId = "templateDocuments.create",
            Tags = new[] { "TemplateDocumentEndpoints" })
        ]
        public override async Task<ActionResult<CreateTemplateDocumentResponse>> HandleAsync(
            CreateTemplateDocumentRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateTemplateDocumentResponse(request.CorrelationId());

            //var document = await _documentRepository.GetByIdAsync(request.DocumentId);// parent entity

            var newTemplateDocument = new TemplateDocument(
                request.DocumentId,
                request.DocumentTypeId,
                request.TemplateId,
                request.TenantId
            );


            await _repository.AddAsync(newTemplateDocument);

            _logger.LogInformation(
                $"TemplateDocument created  with Id {newTemplateDocument.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<TemplateDocumentDto>(newTemplateDocument);

            var templateDocumentCreatedEvent = new TemplateDocumentCreatedEvent(newTemplateDocument, "Mongo-History");
            _messagePublisher.Publish(templateDocumentCreatedEvent);

            response.TemplateDocument = dto;


            return Ok(response);
        }
    }
}