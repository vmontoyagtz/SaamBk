using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.VoiceNoteDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.VoiceNoteDocumentEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdVoiceNoteDocumentRequest>.WithActionResult<
        GetByIdVoiceNoteDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<VoiceNoteDocument> _repository;

        public GetById(
            IRepository<VoiceNoteDocument> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/voiceNoteDocuments/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a VoiceNoteDocument by Id",
            Description = "Gets a VoiceNoteDocument by Id",
            OperationId = "voiceNoteDocuments.GetById",
            Tags = new[] { "VoiceNoteDocumentEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdVoiceNoteDocumentResponse>> HandleAsync(
            [FromRoute] GetByIdVoiceNoteDocumentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdVoiceNoteDocumentResponse(request.CorrelationId());

            var voiceNoteDocument = await _repository.GetByIdAsync(request.RowId);
            if (voiceNoteDocument is null)
            {
                return NotFound();
            }

            response.VoiceNoteDocument = _mapper.Map<VoiceNoteDocumentDto>(voiceNoteDocument);

            return Ok(response);
        }
    }
}