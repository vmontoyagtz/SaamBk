using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorDocumentEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAdvisorDocumentRequest>.WithActionResult<
        GetByIdAdvisorDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorDocument> _repository;

        public GetById(
            IRepository<AdvisorDocument> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorDocuments/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a AdvisorDocument by Id",
            Description = "Gets a AdvisorDocument by Id",
            OperationId = "advisorDocuments.GetById",
            Tags = new[] { "AdvisorDocumentEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAdvisorDocumentResponse>> HandleAsync(
            [FromRoute] GetByIdAdvisorDocumentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAdvisorDocumentResponse(request.CorrelationId());

            var advisorDocument = await _repository.GetByIdAsync(request.RowId);
            if (advisorDocument is null)
            {
                return NotFound();
            }

            response.AdvisorDocument = _mapper.Map<AdvisorDocumentDto>(advisorDocument);

            return Ok(response);
        }
    }
}