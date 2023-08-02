using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TemplateDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TemplateDocumentEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListTemplateDocumentRequest>.WithActionResult<
        ListTemplateDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TemplateDocument> _repository;

        public List(IRepository<TemplateDocument> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/templateDocuments")]
        [SwaggerOperation(
            Summary = "List TemplateDocuments",
            Description = "List TemplateDocuments",
            OperationId = "templateDocuments.List",
            Tags = new[] { "TemplateDocumentEndpoints" })
        ]
        public override async Task<ActionResult<ListTemplateDocumentResponse>> HandleAsync(
            [FromQuery] ListTemplateDocumentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListTemplateDocumentResponse(request.CorrelationId());

            var spec = new TemplateDocumentGetListSpec();
            var templateDocuments = await _repository.ListAsync(spec);
            if (templateDocuments is null)
            {
                return NotFound();
            }

            response.TemplateDocuments = _mapper.Map<List<TemplateDocumentDto>>(templateDocuments);
            response.Count = response.TemplateDocuments.Count;

            return Ok(response);
        }
    }
}