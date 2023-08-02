using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.JournalEntryReference;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.JournalEntryReferenceEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteJournalEntryReferenceRequest>.WithActionResult<
        DeleteJournalEntryReferenceResponse>
    {
        private readonly IRepository<JournalEntryReference> _journalEntryReferenceReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<JournalEntryReference> _repository;

        public Delete(IRepository<JournalEntryReference> JournalEntryReferenceRepository,
            IRepository<JournalEntryReference> JournalEntryReferenceReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = JournalEntryReferenceRepository;
            _journalEntryReferenceReadRepository = JournalEntryReferenceReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/journalEntryReferences/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an JournalEntryReference",
            Description = "Deletes an JournalEntryReference",
            OperationId = "journalEntryReferences.delete",
            Tags = new[] { "JournalEntryReferenceEndpoints" })
        ]
        public override async Task<ActionResult<DeleteJournalEntryReferenceResponse>> HandleAsync(
            [FromRoute] DeleteJournalEntryReferenceRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteJournalEntryReferenceResponse(request.CorrelationId());

            var journalEntryReference = await _journalEntryReferenceReadRepository.GetByIdAsync(request.RowId);

            if (journalEntryReference == null)
            {
                return NotFound();
            }


            var journalEntryReferenceDeletedEvent =
                new JournalEntryReferenceDeletedEvent(journalEntryReference, "Mongo-History");
            _messagePublisher.Publish(journalEntryReferenceDeletedEvent);

            await _repository.DeleteAsync(journalEntryReference);

            return Ok(response);
        }
    }
}