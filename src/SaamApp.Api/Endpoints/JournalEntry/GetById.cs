using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.JournalEntry;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.JournalEntryEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdJournalEntryRequest>.WithActionResult<
        GetByIdJournalEntryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<JournalEntry> _repository;

        public GetById(
            IRepository<JournalEntry> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/journalEntries/{JournalEntryId}")]
        [SwaggerOperation(
            Summary = "Get a JournalEntry by Id",
            Description = "Gets a JournalEntry by Id",
            OperationId = "journalEntries.GetById",
            Tags = new[] { "JournalEntryEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdJournalEntryResponse>> HandleAsync(
            [FromRoute] GetByIdJournalEntryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdJournalEntryResponse(request.CorrelationId());

            var journalEntry = await _repository.GetByIdAsync(request.JournalEntryId);
            if (journalEntry is null)
            {
                return NotFound();
            }

            response.JournalEntry = _mapper.Map<JournalEntryDto>(journalEntry);

            return Ok(response);
        }
    }
}