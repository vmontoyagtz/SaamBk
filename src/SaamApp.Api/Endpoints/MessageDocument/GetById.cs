using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.MessageDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.MessageDocumentEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdMessageDocumentRequest>.WithActionResult<
        GetByIdMessageDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<MessageDocument> _repository;

        public GetById(
            IRepository<MessageDocument> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/messageDocuments/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a MessageDocument by Id",
            Description = "Gets a MessageDocument by Id",
            OperationId = "messageDocuments.GetById",
            Tags = new[] { "MessageDocumentEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdMessageDocumentResponse>> HandleAsync(
            [FromRoute] GetByIdMessageDocumentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdMessageDocumentResponse(request.CorrelationId());

            var messageDocument = await _repository.GetByIdAsync(request.RowId);
            if (messageDocument is null)
            {
                return NotFound();
            }

            response.MessageDocument = _mapper.Map<MessageDocumentDto>(messageDocument);

            return Ok(response);
        }
    }
}