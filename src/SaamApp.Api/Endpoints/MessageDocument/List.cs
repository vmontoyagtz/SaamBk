using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.MessageDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.MessageDocumentEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListMessageDocumentRequest>.WithActionResult<
        ListMessageDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<MessageDocument> _repository;

        public List(IRepository<MessageDocument> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/messageDocuments")]
        [SwaggerOperation(
            Summary = "List MessageDocuments",
            Description = "List MessageDocuments",
            OperationId = "messageDocuments.List",
            Tags = new[] { "MessageDocumentEndpoints" })
        ]
        public override async Task<ActionResult<ListMessageDocumentResponse>> HandleAsync(
            [FromQuery] ListMessageDocumentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListMessageDocumentResponse(request.CorrelationId());

            var spec = new MessageDocumentGetListSpec();
            var messageDocuments = await _repository.ListAsync(spec);
            if (messageDocuments is null)
            {
                return NotFound();
            }

            response.MessageDocuments = _mapper.Map<List<MessageDocumentDto>>(messageDocuments);
            response.Count = response.MessageDocuments.Count;

            return Ok(response);
        }
    }
}