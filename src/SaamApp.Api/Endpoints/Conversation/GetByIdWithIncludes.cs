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
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdConversationRequest>.WithActionResult<
        GetByIdConversationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Conversation> _repository;

        public GetByIdWithIncludes(
            IRepository<Conversation> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/conversations/i/{ConversationId}")]
        [SwaggerOperation(
            Summary = "Get a Conversation by Id With Includes",
            Description = "Gets a Conversation by Id With Includes",
            OperationId = "conversations.GetByIdWithIncludes",
            Tags = new[] { "ConversationEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdConversationResponse>> HandleAsync(
            [FromRoute] GetByIdConversationRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdConversationResponse(request.CorrelationId());

            var spec = new ConversationByIdWithIncludesSpec(request.ConversationId);

            var conversation = await _repository.FirstOrDefaultAsync(spec);


            if (conversation is null)
            {
                return NotFound();
            }

            response.Conversation = _mapper.Map<ConversationDto>(conversation);

            return Ok(response);
        }
    }
}