using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.DocumentType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.DocumentTypeEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListDocumentTypeRequest>.WithActionResult<
        ListDocumentTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<DocumentType> _repository;

        public List(IRepository<DocumentType> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/documentTypes")]
        [SwaggerOperation(
            Summary = "List DocumentTypes",
            Description = "List DocumentTypes",
            OperationId = "documentTypes.List",
            Tags = new[] { "DocumentTypeEndpoints" })
        ]
        public override async Task<ActionResult<ListDocumentTypeResponse>> HandleAsync(
            [FromQuery] ListDocumentTypeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListDocumentTypeResponse(request.CorrelationId());

            var spec = new DocumentTypeGetListSpec();
            var documentTypes = await _repository.ListAsync(spec);
            if (documentTypes is null)
            {
                return NotFound();
            }

            response.DocumentTypes = _mapper.Map<List<DocumentTypeDto>>(documentTypes);
            response.Count = response.DocumentTypes.Count;

            return Ok(response);
        }
    }
}