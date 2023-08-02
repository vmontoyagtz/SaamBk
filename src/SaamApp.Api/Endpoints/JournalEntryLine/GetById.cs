using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.JournalEntryLine;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.JournalEntryLineEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdJournalEntryLineRequest>.WithActionResult<
        GetByIdJournalEntryLineResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<JournalEntryLine> _repository;

        public GetById(
            IRepository<JournalEntryLine> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/journalEntryLines/{JournalEntryLineId}")]
        [SwaggerOperation(
            Summary = "Get a JournalEntryLine by Id",
            Description = "Gets a JournalEntryLine by Id",
            OperationId = "journalEntryLines.GetById",
            Tags = new[] { "JournalEntryLineEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdJournalEntryLineResponse>> HandleAsync(
            [FromRoute] GetByIdJournalEntryLineRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdJournalEntryLineResponse(request.CorrelationId());

            var journalEntryLine = await _repository.GetByIdAsync(request.JournalEntryLineId);
            if (journalEntryLine is null)
            {
                return NotFound();
            }

            response.JournalEntryLine = _mapper.Map<JournalEntryLineDto>(journalEntryLine);

            return Ok(response);
        }
    }
}