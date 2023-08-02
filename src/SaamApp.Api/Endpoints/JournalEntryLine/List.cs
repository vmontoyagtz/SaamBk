using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.JournalEntryLine;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.JournalEntryLineEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListJournalEntryLineRequest>.WithActionResult<
        ListJournalEntryLineResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<JournalEntryLine> _repository;

        public List(IRepository<JournalEntryLine> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/journalEntryLines")]
        [SwaggerOperation(
            Summary = "List JournalEntryLines",
            Description = "List JournalEntryLines",
            OperationId = "journalEntryLines.List",
            Tags = new[] { "JournalEntryLineEndpoints" })
        ]
        public override async Task<ActionResult<ListJournalEntryLineResponse>> HandleAsync(
            [FromQuery] ListJournalEntryLineRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListJournalEntryLineResponse(request.CorrelationId());

            var spec = new JournalEntryLineGetListSpec();
            var journalEntryLines = await _repository.ListAsync(spec);
            if (journalEntryLines is null)
            {
                return NotFound();
            }

            response.JournalEntryLines = _mapper.Map<List<JournalEntryLineDto>>(journalEntryLines);
            response.Count = response.JournalEntryLines.Count;

            return Ok(response);
        }
    }
}