using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.VoiceNoteDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.VoiceNoteDocumentEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListVoiceNoteDocumentRequest>.WithActionResult<
        ListVoiceNoteDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<VoiceNoteDocument> _repository;

        public List(IRepository<VoiceNoteDocument> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/voiceNoteDocuments")]
        [SwaggerOperation(
            Summary = "List VoiceNoteDocuments",
            Description = "List VoiceNoteDocuments",
            OperationId = "voiceNoteDocuments.List",
            Tags = new[] { "VoiceNoteDocumentEndpoints" })
        ]
        public override async Task<ActionResult<ListVoiceNoteDocumentResponse>> HandleAsync(
            [FromQuery] ListVoiceNoteDocumentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListVoiceNoteDocumentResponse(request.CorrelationId());

            var spec = new VoiceNoteDocumentGetListSpec();
            var voiceNoteDocuments = await _repository.ListAsync(spec);
            if (voiceNoteDocuments is null)
            {
                return NotFound();
            }

            response.VoiceNoteDocuments = _mapper.Map<List<VoiceNoteDocumentDto>>(voiceNoteDocuments);
            response.Count = response.VoiceNoteDocuments.Count;

            return Ok(response);
        }
    }
}