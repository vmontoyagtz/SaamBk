using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnitDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitDocumentEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListBusinessUnitDocumentRequest>.WithActionResult<
        ListBusinessUnitDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<BusinessUnitDocument> _repository;

        public List(IRepository<BusinessUnitDocument> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/businessUnitDocuments")]
        [SwaggerOperation(
            Summary = "List BusinessUnitDocuments",
            Description = "List BusinessUnitDocuments",
            OperationId = "businessUnitDocuments.List",
            Tags = new[] { "BusinessUnitDocumentEndpoints" })
        ]
        public override async Task<ActionResult<ListBusinessUnitDocumentResponse>> HandleAsync(
            [FromQuery] ListBusinessUnitDocumentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListBusinessUnitDocumentResponse(request.CorrelationId());

            var spec = new BusinessUnitDocumentGetListSpec();
            var businessUnitDocuments = await _repository.ListAsync(spec);
            if (businessUnitDocuments is null)
            {
                return NotFound();
            }

            response.BusinessUnitDocuments = _mapper.Map<List<BusinessUnitDocumentDto>>(businessUnitDocuments);
            response.Count = response.BusinessUnitDocuments.Count;

            return Ok(response);
        }
    }
}