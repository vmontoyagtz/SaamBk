using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorIdentityDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorIdentityDocumentEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAdvisorIdentityDocumentRequest>.WithActionResult<
        GetByIdAdvisorIdentityDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorIdentityDocument> _repository;

        public GetById(
            IRepository<AdvisorIdentityDocument> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorIdentityDocuments/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a AdvisorIdentityDocument by Id",
            Description = "Gets a AdvisorIdentityDocument by Id",
            OperationId = "advisorIdentityDocuments.GetById",
            Tags = new[] { "AdvisorIdentityDocumentEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAdvisorIdentityDocumentResponse>> HandleAsync(
            [FromRoute] GetByIdAdvisorIdentityDocumentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAdvisorIdentityDocumentResponse(request.CorrelationId());

            var advisorIdentityDocument = await _repository.GetByIdAsync(request.RowId);
            if (advisorIdentityDocument is null)
            {
                return NotFound();
            }

            response.AdvisorIdentityDocument = _mapper.Map<AdvisorIdentityDocumentDto>(advisorIdentityDocument);

            return Ok(response);
        }
    }
}