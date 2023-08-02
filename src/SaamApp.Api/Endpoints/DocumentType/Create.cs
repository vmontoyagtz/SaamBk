using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.DocumentType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.DocumentTypeEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateDocumentTypeRequest>.WithActionResult<
        CreateDocumentTypeResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<DocumentType> _repository;

        public Create(
            IRepository<DocumentType> repository,
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

        [HttpPost("api/documentTypes")]
        [SwaggerOperation(
            Summary = "Creates a new DocumentType",
            Description = "Creates a new DocumentType",
            OperationId = "documentTypes.create",
            Tags = new[] { "DocumentTypeEndpoints" })
        ]
        public override async Task<ActionResult<CreateDocumentTypeResponse>> HandleAsync(
            CreateDocumentTypeRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateDocumentTypeResponse(request.CorrelationId());


            var newDocumentType = new DocumentType(
                Guid.NewGuid(),
                request.DocumentTypeName,
                request.DocumentTypeDescription,
                request.TenantId
            );


            await _repository.AddAsync(newDocumentType);

            _logger.LogInformation(
                $"DocumentType created  with Id {newDocumentType.DocumentTypeId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<DocumentTypeDto>(newDocumentType);

            var documentTypeCreatedEvent = new DocumentTypeCreatedEvent(newDocumentType, "Mongo-History");
            _messagePublisher.Publish(documentTypeCreatedEvent);

            response.DocumentType = dto;


            return Ok(response);
        }
    }
}