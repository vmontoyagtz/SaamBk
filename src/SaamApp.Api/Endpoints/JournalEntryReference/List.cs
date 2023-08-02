using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.JournalEntryReference;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.JournalEntryReferenceEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListJournalEntryReferenceRequest>.WithActionResult<
        ListJournalEntryReferenceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<JournalEntryReference> _repository;

        public List(IRepository<JournalEntryReference> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/journalEntryReferences")]
        [SwaggerOperation(
            Summary = "List JournalEntryReferences",
            Description = "List JournalEntryReferences",
            OperationId = "journalEntryReferences.List",
            Tags = new[] { "JournalEntryReferenceEndpoints" })
        ]
        public override async Task<ActionResult<ListJournalEntryReferenceResponse>> HandleAsync(
            [FromQuery] ListJournalEntryReferenceRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListJournalEntryReferenceResponse(request.CorrelationId());

            var spec = new JournalEntryReferenceGetListSpec();
            var journalEntryReferences = await _repository.ListAsync(spec);
            if (journalEntryReferences is null)
            {
                return NotFound();
            }

            response.JournalEntryReferences = _mapper.Map<List<JournalEntryReferenceDto>>(journalEntryReferences);
            response.Count = response.JournalEntryReferences.Count;

            return Ok(response);
        }
    }
}