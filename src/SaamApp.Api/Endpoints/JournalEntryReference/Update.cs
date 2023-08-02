using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.JournalEntryReference;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.JournalEntryReferenceEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateJournalEntryReferenceRequest>.WithActionResult<
        UpdateJournalEntryReferenceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<JournalEntryReference> _repository;

        public Update(
            IRepository<JournalEntryReference> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/journalEntryReferences")]
        [SwaggerOperation(
            Summary = "Updates a JournalEntryReference",
            Description = "Updates a JournalEntryReference",
            OperationId = "journalEntryReferences.update",
            Tags = new[] { "JournalEntryReferenceEndpoints" })
        ]
        public override async Task<ActionResult<UpdateJournalEntryReferenceResponse>> HandleAsync(
            UpdateJournalEntryReferenceRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateJournalEntryReferenceResponse(request.CorrelationId());

            var jeroeruerToUpdate = _mapper.Map<JournalEntryReference>(request);

            var journalEntryReferenceToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (journalEntryReferenceToUpdateTest is null)
            {
                return NotFound();
            }

            // jeroeruerToUpdate.UpdateJournalEntryLineForJournalEntryReference(request.JournalEntryLineId);
            await _repository.UpdateAsync(jeroeruerToUpdate);

            var journalEntryReferenceUpdatedEvent =
                new JournalEntryReferenceUpdatedEvent(jeroeruerToUpdate, "Mongo-History");
            _messagePublisher.Publish(journalEntryReferenceUpdatedEvent);

            var dto = _mapper.Map<JournalEntryReferenceDto>(jeroeruerToUpdate);
            response.JournalEntryReference = dto;

            return Ok(response);
        }
    }
}