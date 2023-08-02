using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.IdentityDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.IdentityDocumentEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdIdentityDocumentRequest>.WithActionResult<
        GetByIdIdentityDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<IdentityDocument> _repository;

        public GetById(
            IRepository<IdentityDocument> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/identityDocuments/{IdentityDocumentId}")]
        [SwaggerOperation(
            Summary = "Get a IdentityDocument by Id",
            Description = "Gets a IdentityDocument by Id",
            OperationId = "identityDocuments.GetById",
            Tags = new[] { "IdentityDocumentEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdIdentityDocumentResponse>> HandleAsync(
            [FromRoute] GetByIdIdentityDocumentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdIdentityDocumentResponse(request.CorrelationId());

            var identityDocument = await _repository.GetByIdAsync(request.IdentityDocumentId);
            if (identityDocument is null)
            {
                return NotFound();
            }

            response.IdentityDocument = _mapper.Map<IdentityDocumentDto>(identityDocument);

            return Ok(response);
        }
    }
}