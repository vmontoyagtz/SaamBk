using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Conversation;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ConversationEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdConversationRequest>.WithActionResult<
        GetByIdConversationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Conversation> _repository;

        public GetById(
            IRepository<Conversation> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/conversations/{ConversationId}")]
        [SwaggerOperation(
            Summary = "Get a Conversation by Id",
            Description = "Gets a Conversation by Id",
            OperationId = "conversations.GetById",
            Tags = new[] { "ConversationEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdConversationResponse>> HandleAsync(
            [FromRoute] GetByIdConversationRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdConversationResponse(request.CorrelationId());

            var conversation = await _repository.GetByIdAsync(request.ConversationId);
            if (conversation is null)
            {
                return NotFound();
            }

            response.Conversation = _mapper.Map<ConversationDto>(conversation);

            return Ok(response);
        }
    }
}