using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.IdentityDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.IdentityDocumentEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListIdentityDocumentRequest>.WithActionResult<
        ListIdentityDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<IdentityDocument> _repository;

        public List(IRepository<IdentityDocument> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/identityDocuments")]
        [SwaggerOperation(
            Summary = "List IdentityDocuments",
            Description = "List IdentityDocuments",
            OperationId = "identityDocuments.List",
            Tags = new[] { "IdentityDocumentEndpoints" })
        ]
        public override async Task<ActionResult<ListIdentityDocumentResponse>> HandleAsync(
            [FromQuery] ListIdentityDocumentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListIdentityDocumentResponse(request.CorrelationId());

            var spec = new IdentityDocumentGetListSpec();
            var identityDocuments = await _repository.ListAsync(spec);
            if (identityDocuments is null)
            {
                return NotFound();
            }

            response.IdentityDocuments = _mapper.Map<List<IdentityDocumentDto>>(identityDocuments);
            response.Count = response.IdentityDocuments.Count;

            return Ok(response);
        }
    }
}