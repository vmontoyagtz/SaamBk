using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.JournalEntry;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.JournalEntryEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListJournalEntryRequest>.WithActionResult<
        ListJournalEntryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<JournalEntry> _repository;

        public List(IRepository<JournalEntry> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/journalEntries")]
        [SwaggerOperation(
            Summary = "List JournalEntries",
            Description = "List JournalEntries",
            OperationId = "journalEntries.List",
            Tags = new[] { "JournalEntryEndpoints" })
        ]
        public override async Task<ActionResult<ListJournalEntryResponse>> HandleAsync(
            [FromQuery] ListJournalEntryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListJournalEntryResponse(request.CorrelationId());

            var spec = new JournalEntryGetListSpec();
            var journalEntries = await _repository.ListAsync(spec);
            if (journalEntries is null)
            {
                return NotFound();
            }

            response.JournalEntries = _mapper.Map<List<JournalEntryDto>>(journalEntries);
            response.Count = response.JournalEntries.Count;

            return Ok(response);
        }
    }
}