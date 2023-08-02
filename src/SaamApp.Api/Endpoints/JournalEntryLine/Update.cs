using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.JournalEntryLine;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.JournalEntryLineEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateJournalEntryLineRequest>.WithActionResult<
        UpdateJournalEntryLineResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<JournalEntryLine> _repository;

        public Update(
            IRepository<JournalEntryLine> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/journalEntryLines")]
        [SwaggerOperation(
            Summary = "Updates a JournalEntryLine",
            Description = "Updates a JournalEntryLine",
            OperationId = "journalEntryLines.update",
            Tags = new[] { "JournalEntryLineEndpoints" })
        ]
        public override async Task<ActionResult<UpdateJournalEntryLineResponse>> HandleAsync(
            UpdateJournalEntryLineRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateJournalEntryLineResponse(request.CorrelationId());

            var jeloeluelToUpdate = _mapper.Map<JournalEntryLine>(request);

            var journalEntryLineToUpdateTest = await _repository.GetByIdAsync(request.JournalEntryLineId);
            if (journalEntryLineToUpdateTest is null)
            {
                return NotFound();
            }

            //jeloeluelToUpdate.UpdateAccountForJournalEntryLine(request.AccountId);
            //jeloeluelToUpdate.UpdateFinancialAccountingPeriodForJournalEntryLine(request.FinancialAccountingPeriodId);
            //jeloeluelToUpdate.UpdateJournalEntryForJournalEntryLine(request.JournalEntryId);
            await _repository.UpdateAsync(jeloeluelToUpdate);

            var journalEntryLineUpdatedEvent = new JournalEntryLineUpdatedEvent(jeloeluelToUpdate, "Mongo-History");
            _messagePublisher.Publish(journalEntryLineUpdatedEvent);

            var dto = _mapper.Map<JournalEntryLineDto>(jeloeluelToUpdate);
            response.JournalEntryLine = dto;

            return Ok(response);
        }
    }
}