using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnitDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitDocumentEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdBusinessUnitDocumentRequest>.WithActionResult<
        GetByIdBusinessUnitDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<BusinessUnitDocument> _repository;

        public GetById(
            IRepository<BusinessUnitDocument> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/businessUnitDocuments/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a BusinessUnitDocument by Id",
            Description = "Gets a BusinessUnitDocument by Id",
            OperationId = "businessUnitDocuments.GetById",
            Tags = new[] { "BusinessUnitDocumentEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdBusinessUnitDocumentResponse>> HandleAsync(
            [FromRoute] GetByIdBusinessUnitDocumentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdBusinessUnitDocumentResponse(request.CorrelationId());

            var businessUnitDocument = await _repository.GetByIdAsync(request.RowId);
            if (businessUnitDocument is null)
            {
                return NotFound();
            }

            response.BusinessUnitDocument = _mapper.Map<BusinessUnitDocumentDto>(businessUnitDocument);

            return Ok(response);
        }
    }
}