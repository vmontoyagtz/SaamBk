using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.DocumentType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.DocumentTypeEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdDocumentTypeRequest>.WithActionResult<
        GetByIdDocumentTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<DocumentType> _repository;

        public GetById(
            IRepository<DocumentType> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/documentTypes/{DocumentTypeId}")]
        [SwaggerOperation(
            Summary = "Get a DocumentType by Id",
            Description = "Gets a DocumentType by Id",
            OperationId = "documentTypes.GetById",
            Tags = new[] { "DocumentTypeEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdDocumentTypeResponse>> HandleAsync(
            [FromRoute] GetByIdDocumentTypeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdDocumentTypeResponse(request.CorrelationId());

            var documentType = await _repository.GetByIdAsync(request.DocumentTypeId);
            if (documentType is null)
            {
                return NotFound();
            }

            response.DocumentType = _mapper.Map<DocumentTypeDto>(documentType);

            return Ok(response);
        }
    }
}