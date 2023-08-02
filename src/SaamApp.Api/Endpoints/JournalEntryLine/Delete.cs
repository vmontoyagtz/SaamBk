using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.JournalEntryLine;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.JournalEntryLineEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteJournalEntryLineRequest>.WithActionResult<
        DeleteJournalEntryLineResponse>
    {
        private readonly IRepository<JournalEntryLine> _journalEntryLineReadRepository;
        private readonly IRepository<JournalEntryReference> _journalEntryReferenceRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<JournalEntryLine> _repository;

        public Delete(IRepository<JournalEntryLine> JournalEntryLineRepository,
            IRepository<JournalEntryLine> JournalEntryLineReadRepository,
            IRepository<JournalEntryReference> journalEntryReferenceRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = JournalEntryLineRepository;
            _journalEntryLineReadRepository = JournalEntryLineReadRepository;
            _journalEntryReferenceRepository = journalEntryReferenceRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/journalEntryLines/{JournalEntryLineId}")]
        [SwaggerOperation(
            Summary = "Deletes an JournalEntryLine",
            Description = "Deletes an JournalEntryLine",
            OperationId = "journalEntryLines.delete",
            Tags = new[] { "JournalEntryLineEndpoints" })
        ]
        public override async Task<ActionResult<DeleteJournalEntryLineResponse>> HandleAsync(
            [FromRoute] DeleteJournalEntryLineRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteJournalEntryLineResponse(request.CorrelationId());

            var journalEntryLine = await _journalEntryLineReadRepository.GetByIdAsync(request.JournalEntryLineId);

            if (journalEntryLine == null)
            {
                return NotFound();
            }

            var journalEntryReferenceSpec =
                new GetJournalEntryReferenceWithJournalEntryLineKeySpec(journalEntryLine.JournalEntryLineId);
            var journalEntryReferences = await _journalEntryReferenceRepository.ListAsync(journalEntryReferenceSpec);
            await _journalEntryReferenceRepository.DeleteRangeAsync(journalEntryReferences);

            var journalEntryLineDeletedEvent = new JournalEntryLineDeletedEvent(journalEntryLine, "Mongo-History");
            _messagePublisher.Publish(journalEntryLineDeletedEvent);

            await _repository.DeleteAsync(journalEntryLine);

            return Ok(response);
        }
    }
}