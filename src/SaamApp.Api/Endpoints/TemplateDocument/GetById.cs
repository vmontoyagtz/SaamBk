using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TemplateDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TemplateDocumentEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdTemplateDocumentRequest>.WithActionResult<
        GetByIdTemplateDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TemplateDocument> _repository;

        public GetById(
            IRepository<TemplateDocument> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/templateDocuments/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a TemplateDocument by Id",
            Description = "Gets a TemplateDocument by Id",
            OperationId = "templateDocuments.GetById",
            Tags = new[] { "TemplateDocumentEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdTemplateDocumentResponse>> HandleAsync(
            [FromRoute] GetByIdTemplateDocumentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdTemplateDocumentResponse(request.CorrelationId());

            var templateDocument = await _repository.GetByIdAsync(request.RowId);
            if (templateDocument is null)
            {
                return NotFound();
            }

            response.TemplateDocument = _mapper.Map<TemplateDocumentDto>(templateDocument);

            return Ok(response);
        }
    }
}