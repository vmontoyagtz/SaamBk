using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Document;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.DocumentEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdDocumentRequest>.WithActionResult<
        GetByIdDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Document> _repository;

        public GetById(
            IRepository<Document> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/documents/{DocumentId}")]
        [SwaggerOperation(
            Summary = "Get a Document by Id",
            Description = "Gets a Document by Id",
            OperationId = "documents.GetById",
            Tags = new[] { "DocumentEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdDocumentResponse>> HandleAsync(
            [FromRoute] GetByIdDocumentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdDocumentResponse(request.CorrelationId());

            var document = await _repository.GetByIdAsync(request.DocumentId);
            if (document is null)
            {
                return NotFound();
            }

            response.Document = _mapper.Map<DocumentDto>(document);

            return Ok(response);
        }
    }
}