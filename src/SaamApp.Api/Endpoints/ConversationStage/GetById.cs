using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.ConversationStage;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ConversationStageEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdConversationStageRequest>.WithActionResult<
        GetByIdConversationStageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ConversationStage> _repository;

        public GetById(
            IRepository<ConversationStage> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/conversationStages/{ConversationStageId}")]
        [SwaggerOperation(
            Summary = "Get a ConversationStage by Id",
            Description = "Gets a ConversationStage by Id",
            OperationId = "conversationStages.GetById",
            Tags = new[] { "ConversationStageEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdConversationStageResponse>> HandleAsync(
            [FromRoute] GetByIdConversationStageRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdConversationStageResponse(request.CorrelationId());

            var conversationStage = await _repository.GetByIdAsync(request.ConversationStageId);
            if (conversationStage is null)
            {
                return NotFound();
            }

            response.ConversationStage = _mapper.Map<ConversationStageDto>(conversationStage);

            return Ok(response);
        }
    }
}