using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Document;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.DocumentEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListDocumentRequest>.WithActionResult<ListDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Document> _repository;

        public List(IRepository<Document> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/documents")]
        [SwaggerOperation(
            Summary = "List Documents",
            Description = "List Documents",
            OperationId = "documents.List",
            Tags = new[] { "DocumentEndpoints" })
        ]
        public override async Task<ActionResult<ListDocumentResponse>> HandleAsync(
            [FromQuery] ListDocumentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListDocumentResponse(request.CorrelationId());

            var spec = new DocumentGetListSpec();
            var documents = await _repository.ListAsync(spec);
            if (documents is null)
            {
                return NotFound();
            }

            response.Documents = _mapper.Map<List<DocumentDto>>(documents);
            response.Count = response.Documents.Count;

            return Ok(response);
        }
    }
}