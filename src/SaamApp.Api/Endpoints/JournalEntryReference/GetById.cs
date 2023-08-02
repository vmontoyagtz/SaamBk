using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.JournalEntryReference;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.JournalEntryReferenceEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdJournalEntryReferenceRequest>.WithActionResult<
        GetByIdJournalEntryReferenceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<JournalEntryReference> _repository;

        public GetById(
            IRepository<JournalEntryReference> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/journalEntryReferences/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a JournalEntryReference by Id",
            Description = "Gets a JournalEntryReference by Id",
            OperationId = "journalEntryReferences.GetById",
            Tags = new[] { "JournalEntryReferenceEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdJournalEntryReferenceResponse>> HandleAsync(
            [FromRoute] GetByIdJournalEntryReferenceRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdJournalEntryReferenceResponse(request.CorrelationId());

            var journalEntryReference = await _repository.GetByIdAsync(request.RowId);
            if (journalEntryReference is null)
            {
                return NotFound();
            }

            response.JournalEntryReference = _mapper.Map<JournalEntryReferenceDto>(journalEntryReference);

            return Ok(response);
        }
    }
}