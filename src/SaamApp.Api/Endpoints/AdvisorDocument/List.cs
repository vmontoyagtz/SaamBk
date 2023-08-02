using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorDocumentEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListAdvisorDocumentRequest>.WithActionResult<
        ListAdvisorDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorDocument> _repository;

        public List(IRepository<AdvisorDocument> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorDocuments")]
        [SwaggerOperation(
            Summary = "List AdvisorDocuments",
            Description = "List AdvisorDocuments",
            OperationId = "advisorDocuments.List",
            Tags = new[] { "AdvisorDocumentEndpoints" })
        ]
        public override async Task<ActionResult<ListAdvisorDocumentResponse>> HandleAsync(
            [FromQuery] ListAdvisorDocumentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAdvisorDocumentResponse(request.CorrelationId());

            var spec = new AdvisorDocumentGetListSpec();
            var advisorDocuments = await _repository.ListAsync(spec);
            if (advisorDocuments is null)
            {
                return NotFound();
            }

            response.AdvisorDocuments = _mapper.Map<List<AdvisorDocumentDto>>(advisorDocuments);
            response.Count = response.AdvisorDocuments.Count;

            return Ok(response);
        }
    }
}