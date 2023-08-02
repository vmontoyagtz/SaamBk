using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.UnansweredConversation;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.UnansweredConversationEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListUnansweredConversationRequest>.WithActionResult<
        ListUnansweredConversationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<UnansweredConversation> _repository;

        public List(IRepository<UnansweredConversation> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/unansweredConversations")]
        [SwaggerOperation(
            Summary = "List UnansweredConversations",
            Description = "List UnansweredConversations",
            OperationId = "unansweredConversations.List",
            Tags = new[] { "UnansweredConversationEndpoints" })
        ]
        public override async Task<ActionResult<ListUnansweredConversationResponse>> HandleAsync(
            [FromQuery] ListUnansweredConversationRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListUnansweredConversationResponse(request.CorrelationId());

            var spec = new UnansweredConversationGetListSpec();
            var unansweredConversations = await _repository.ListAsync(spec);
            if (unansweredConversations is null)
            {
                return NotFound();
            }

            response.UnansweredConversations = _mapper.Map<List<UnansweredConversationDto>>(unansweredConversations);
            response.Count = response.UnansweredConversations.Count;

            return Ok(response);
        }
    }
}