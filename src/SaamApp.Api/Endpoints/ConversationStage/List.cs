using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.ConversationStage;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ConversationStageEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListConversationStageRequest>.WithActionResult<
        ListConversationStageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ConversationStage> _repository;

        public List(IRepository<ConversationStage> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/conversationStages")]
        [SwaggerOperation(
            Summary = "List ConversationStages",
            Description = "List ConversationStages",
            OperationId = "conversationStages.List",
            Tags = new[] { "ConversationStageEndpoints" })
        ]
        public override async Task<ActionResult<ListConversationStageResponse>> HandleAsync(
            [FromQuery] ListConversationStageRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListConversationStageResponse(request.CorrelationId());

            var spec = new ConversationStageGetListSpec();
            var conversationStages = await _repository.ListAsync(spec);
            if (conversationStages is null)
            {
                return NotFound();
            }

            response.ConversationStages = _mapper.Map<List<ConversationStageDto>>(conversationStages);
            response.Count = response.ConversationStages.Count;

            return Ok(response);
        }
    }
}