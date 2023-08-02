using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.JournalEntry;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.JournalEntryEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateJournalEntryRequest>.WithActionResult<
        UpdateJournalEntryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<JournalEntry> _repository;

        public Update(
            IRepository<JournalEntry> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/journalEntries")]
        [SwaggerOperation(
            Summary = "Updates a JournalEntry",
            Description = "Updates a JournalEntry",
            OperationId = "journalEntries.update",
            Tags = new[] { "JournalEntryEndpoints" })
        ]
        public override async Task<ActionResult<UpdateJournalEntryResponse>> HandleAsync(
            UpdateJournalEntryRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateJournalEntryResponse(request.CorrelationId());

            var jeoeueToUpdate = _mapper.Map<JournalEntry>(request);

            var journalEntryToUpdateTest = await _repository.GetByIdAsync(request.JournalEntryId);
            if (journalEntryToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(jeoeueToUpdate);

            var journalEntryUpdatedEvent = new JournalEntryUpdatedEvent(jeoeueToUpdate, "Mongo-History");
            _messagePublisher.Publish(journalEntryUpdatedEvent);

            var dto = _mapper.Map<JournalEntryDto>(jeoeueToUpdate);
            response.JournalEntry = dto;

            return Ok(response);
        }
    }
}