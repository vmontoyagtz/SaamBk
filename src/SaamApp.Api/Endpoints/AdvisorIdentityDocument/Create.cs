using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AdvisorIdentityDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorIdentityDocumentEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAdvisorIdentityDocumentRequest>.WithActionResult<
        CreateAdvisorIdentityDocumentResponse>
    {
        private readonly IRepository<Advisor> _advisorRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorIdentityDocument> _repository;

        public Create(
            IRepository<AdvisorIdentityDocument> repository,
            IRepository<Advisor> advisorRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _advisorRepository = advisorRepository;
        }

        [HttpPost("api/advisorIdentityDocuments")]
        [SwaggerOperation(
            Summary = "Creates a new AdvisorIdentityDocument",
            Description = "Creates a new AdvisorIdentityDocument",
            OperationId = "advisorIdentityDocuments.create",
            Tags = new[] { "AdvisorIdentityDocumentEndpoints" })
        ]
        public override async Task<ActionResult<CreateAdvisorIdentityDocumentResponse>> HandleAsync(
            CreateAdvisorIdentityDocumentRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAdvisorIdentityDocumentResponse(request.CorrelationId());

            //var advisor = await _advisorRepository.GetByIdAsync(request.AdvisorId);// parent entity

            var newAdvisorIdentityDocument = new AdvisorIdentityDocument(
                request.AdvisorId,
                request.DocumentId,
                request.DocumentTypeId,
                request.IdentityDocumentId
            );


            await _repository.AddAsync(newAdvisorIdentityDocument);

            _logger.LogInformation(
                $"AdvisorIdentityDocument created  with Id {newAdvisorIdentityDocument.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AdvisorIdentityDocumentDto>(newAdvisorIdentityDocument);

            var advisorIdentityDocumentCreatedEvent =
                new AdvisorIdentityDocumentCreatedEvent(newAdvisorIdentityDocument, "Mongo-History");
            _messagePublisher.Publish(advisorIdentityDocumentCreatedEvent);

            response.AdvisorIdentityDocument = dto;


            return Ok(response);
        }
    }
}