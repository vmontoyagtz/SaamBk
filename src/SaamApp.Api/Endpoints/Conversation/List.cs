using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Conversation;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ConversationEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListConversationRequest>.WithActionResult<
        ListConversationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Conversation> _repository;

        public List(IRepository<Conversation> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/conversations")]
        [SwaggerOperation(
            Summary = "List Conversations",
            Description = "List Conversations",
            OperationId = "conversations.List",
            Tags = new[] { "ConversationEndpoints" })
        ]
        public override async Task<ActionResult<ListConversationResponse>> HandleAsync(
            [FromQuery] ListConversationRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListConversationResponse(request.CorrelationId());

            var spec = new ConversationGetListSpec();
            var conversations = await _repository.ListAsync(spec);
            if (conversations is null)
            {
                return NotFound();
            }

            response.Conversations = _mapper.Map<List<ConversationDto>>(conversations);
            response.Count = response.Conversations.Count;

            return Ok(response);
        }
    }
}