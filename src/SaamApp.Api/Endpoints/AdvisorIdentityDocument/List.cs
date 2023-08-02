using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorIdentityDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorIdentityDocumentEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListAdvisorIdentityDocumentRequest>.WithActionResult<
        ListAdvisorIdentityDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorIdentityDocument> _repository;

        public List(IRepository<AdvisorIdentityDocument> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorIdentityDocuments")]
        [SwaggerOperation(
            Summary = "List AdvisorIdentityDocuments",
            Description = "List AdvisorIdentityDocuments",
            OperationId = "advisorIdentityDocuments.List",
            Tags = new[] { "AdvisorIdentityDocumentEndpoints" })
        ]
        public override async Task<ActionResult<ListAdvisorIdentityDocumentResponse>> HandleAsync(
            [FromQuery] ListAdvisorIdentityDocumentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAdvisorIdentityDocumentResponse(request.CorrelationId());

            var spec = new AdvisorIdentityDocumentGetListSpec();
            var advisorIdentityDocuments = await _repository.ListAsync(spec);
            if (advisorIdentityDocuments is null)
            {
                return NotFound();
            }

            response.AdvisorIdentityDocuments = _mapper.Map<List<AdvisorIdentityDocumentDto>>(advisorIdentityDocuments);
            response.Count = response.AdvisorIdentityDocuments.Count;

            return Ok(response);
        }
    }
}