using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.JournalEntry;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.JournalEntryEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteJournalEntryRequest>.WithActionResult<
        DeleteJournalEntryResponse>
    {
        private readonly IRepository<JournalEntryLine> _journalEntryLineRepository;
        private readonly IRepository<JournalEntry> _journalEntryReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<JournalEntry> _repository;

        public Delete(IRepository<JournalEntry> JournalEntryRepository,
            IRepository<JournalEntry> JournalEntryReadRepository,
            IRepository<JournalEntryLine> journalEntryLineRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = JournalEntryRepository;
            _journalEntryReadRepository = JournalEntryReadRepository;
            _journalEntryLineRepository = journalEntryLineRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/journalEntries/{JournalEntryId}")]
        [SwaggerOperation(
            Summary = "Deletes an JournalEntry",
            Description = "Deletes an JournalEntry",
            OperationId = "journalEntries.delete",
            Tags = new[] { "JournalEntryEndpoints" })
        ]
        public override async Task<ActionResult<DeleteJournalEntryResponse>> HandleAsync(
            [FromRoute] DeleteJournalEntryRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteJournalEntryResponse(request.CorrelationId());

            var journalEntry = await _journalEntryReadRepository.GetByIdAsync(request.JournalEntryId);

            if (journalEntry == null)
            {
                return NotFound();
            }

            var journalEntryLineSpec = new GetJournalEntryLineWithJournalEntryKeySpec(journalEntry.JournalEntryId);
            var journalEntryLines = await _journalEntryLineRepository.ListAsync(journalEntryLineSpec);
            await _journalEntryLineRepository
                .DeleteRangeAsync(journalEntryLines); // you could use soft delete with IsDeleted = true

            var journalEntryDeletedEvent = new JournalEntryDeletedEvent(journalEntry, "Mongo-History");
            _messagePublisher.Publish(journalEntryDeletedEvent);

            await _repository.DeleteAsync(journalEntry);

            return Ok(response);
        }
    }
}