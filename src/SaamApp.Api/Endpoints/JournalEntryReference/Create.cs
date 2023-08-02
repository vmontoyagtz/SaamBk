using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.JournalEntryReference;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.JournalEntryReferenceEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateJournalEntryReferenceRequest>.WithActionResult<
        CreateJournalEntryReferenceResponse>
    {
        private readonly IRepository<JournalEntryLine> _journalEntryLineRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<JournalEntryReference> _repository;

        public Create(
            IRepository<JournalEntryReference> repository,
            IRepository<JournalEntryLine> journalEntryLineRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _journalEntryLineRepository = journalEntryLineRepository;
        }

        [HttpPost("api/journalEntryReferences")]
        [SwaggerOperation(
            Summary = "Creates a new JournalEntryReference",
            Description = "Creates a new JournalEntryReference",
            OperationId = "journalEntryReferences.create",
            Tags = new[] { "JournalEntryReferenceEndpoints" })
        ]
        public override async Task<ActionResult<CreateJournalEntryReferenceResponse>> HandleAsync(
            CreateJournalEntryReferenceRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateJournalEntryReferenceResponse(request.CorrelationId());

            //var journalEntryLine = await _journalEntryLineRepository.GetByIdAsync(request.JournalEntryLineId);// parent entity

            var newJournalEntryReference = new JournalEntryReference(
                request.JournalEntryLineId,
                request.JournalEntryTypeRefId,
                request.JournalEntryTypeName,
                request.Description,
                request.TenantId
            );


            await _repository.AddAsync(newJournalEntryReference);

            _logger.LogInformation(
                $"JournalEntryReference created  with Id {newJournalEntryReference.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<JournalEntryReferenceDto>(newJournalEntryReference);

            var journalEntryReferenceCreatedEvent =
                new JournalEntryReferenceCreatedEvent(newJournalEntryReference, "Mongo-History");
            _messagePublisher.Publish(journalEntryReferenceCreatedEvent);

            response.JournalEntryReference = dto;


            return Ok(response);
        }
    }
}