using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AdvisorDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorDocumentEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAdvisorDocumentRequest>.WithActionResult<
        CreateAdvisorDocumentResponse>
    {
        private readonly IRepository<Advisor> _advisorRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorDocument> _repository;

        public Create(
            IRepository<AdvisorDocument> repository,
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

        [HttpPost("api/advisorDocuments")]
        [SwaggerOperation(
            Summary = "Creates a new AdvisorDocument",
            Description = "Creates a new AdvisorDocument",
            OperationId = "advisorDocuments.create",
            Tags = new[] { "AdvisorDocumentEndpoints" })
        ]
        public override async Task<ActionResult<CreateAdvisorDocumentResponse>> HandleAsync(
            CreateAdvisorDocumentRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAdvisorDocumentResponse(request.CorrelationId());

            //var advisor = await _advisorRepository.GetByIdAsync(request.AdvisorId);// parent entity

            var newAdvisorDocument = new AdvisorDocument(
                request.AdvisorId,
                request.DocumentId,
                request.DocumentTypeId
            );


            await _repository.AddAsync(newAdvisorDocument);

            _logger.LogInformation(
                $"AdvisorDocument created  with Id {newAdvisorDocument.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AdvisorDocumentDto>(newAdvisorDocument);

            var advisorDocumentCreatedEvent = new AdvisorDocumentCreatedEvent(newAdvisorDocument, "Mongo-History");
            _messagePublisher.Publish(advisorDocumentCreatedEvent);

            response.AdvisorDocument = dto;


            return Ok(response);
        }
    }
}