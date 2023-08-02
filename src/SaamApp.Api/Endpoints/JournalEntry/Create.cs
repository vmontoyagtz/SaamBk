using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.JournalEntry;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.JournalEntryEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateJournalEntryRequest>.WithActionResult<
        CreateJournalEntryResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<JournalEntry> _repository;

        public Create(
            IRepository<JournalEntry> repository,
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

        [HttpPost("api/journalEntries")]
        [SwaggerOperation(
            Summary = "Creates a new JournalEntry",
            Description = "Creates a new JournalEntry",
            OperationId = "journalEntries.create",
            Tags = new[] { "JournalEntryEndpoints" })
        ]
        public override async Task<ActionResult<CreateJournalEntryResponse>> HandleAsync(
            CreateJournalEntryRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateJournalEntryResponse(request.CorrelationId());


            var newJournalEntry = new JournalEntry(
                Guid.NewGuid(),
                request.ReferenceId,
                request.ReferenceIdDescription,
                request.TransactionDate,
                request.JournalEntryTypeId,
                request.TotalTaxAmount,
                request.TotalAmount,
                request.Description,
                request.TenantId
            );


            await _repository.AddAsync(newJournalEntry);

            _logger.LogInformation(
                $"JournalEntry created  with Id {newJournalEntry.JournalEntryId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<JournalEntryDto>(newJournalEntry);

            var journalEntryCreatedEvent = new JournalEntryCreatedEvent(newJournalEntry, "Mongo-History");
            _messagePublisher.Publish(journalEntryCreatedEvent);

            response.JournalEntry = dto;


            return Ok(response);
        }
    }
}