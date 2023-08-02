using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.UnansweredConversation;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.UnansweredConversationEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdUnansweredConversationRequest>.WithActionResult<
        GetByIdUnansweredConversationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<UnansweredConversation> _repository;

        public GetById(
            IRepository<UnansweredConversation> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/unansweredConversations/{UnansweredConversationId}")]
        [SwaggerOperation(
            Summary = "Get a UnansweredConversation by Id",
            Description = "Gets a UnansweredConversation by Id",
            OperationId = "unansweredConversations.GetById",
            Tags = new[] { "UnansweredConversationEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdUnansweredConversationResponse>> HandleAsync(
            [FromRoute] GetByIdUnansweredConversationRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdUnansweredConversationResponse(request.CorrelationId());

            var unansweredConversation = await _repository.GetByIdAsync(request.UnansweredConversationId);
            if (unansweredConversation is null)
            {
                return NotFound();
            }

            response.UnansweredConversation = _mapper.Map<UnansweredConversationDto>(unansweredConversation);

            return Ok(response);
        }
    }
}