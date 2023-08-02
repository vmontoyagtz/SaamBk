using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.IdentityDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.IdentityDocumentEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateIdentityDocumentRequest>.WithActionResult<
        CreateIdentityDocumentResponse>
    {
        private readonly IRepository<Country> _countryRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<IdentityDocument> _repository;

        public Create(
            IRepository<IdentityDocument> repository,
            IRepository<Country> countryRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _countryRepository = countryRepository;
        }

        [HttpPost("api/identityDocuments")]
        [SwaggerOperation(
            Summary = "Creates a new IdentityDocument",
            Description = "Creates a new IdentityDocument",
            OperationId = "identityDocuments.create",
            Tags = new[] { "IdentityDocumentEndpoints" })
        ]
        public override async Task<ActionResult<CreateIdentityDocumentResponse>> HandleAsync(
            CreateIdentityDocumentRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateIdentityDocumentResponse(request.CorrelationId());

            //var country = await _countryRepository.GetByIdAsync(request.CountryId);// parent entity

            var newIdentityDocument = new IdentityDocument(
                Guid.NewGuid(),
                request.CountryId,
                request.IdentityDocumentName,
                request.IdentityDocumentNumber,
                request.IdentityDocumentDescription,
                request.TenantId
            );


            await _repository.AddAsync(newIdentityDocument);

            _logger.LogInformation(
                $"IdentityDocument created  with Id {newIdentityDocument.IdentityDocumentId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<IdentityDocumentDto>(newIdentityDocument);

            var identityDocumentCreatedEvent = new IdentityDocumentCreatedEvent(newIdentityDocument, "Mongo-History");
            _messagePublisher.Publish(identityDocumentCreatedEvent);

            response.IdentityDocument = dto;


            return Ok(response);
        }
    }
}