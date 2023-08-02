using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiModel;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiModelEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAiModelRequest>.WithActionResult<
        DeleteAiModelResponse>
    {
        private readonly IRepository<AiModel> _aiModelReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AiModel> _repository;

        public Delete(IRepository<AiModel> AiModelRepository, IRepository<AiModel> AiModelReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AiModelRepository;
            _aiModelReadRepository = AiModelReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/aiModels/{AiModelId}")]
        [SwaggerOperation(
            Summary = "Deletes an AiModel",
            Description = "Deletes an AiModel",
            OperationId = "aiModels.delete",
            Tags = new[] { "AiModelEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAiModelResponse>> HandleAsync(
            [FromRoute] DeleteAiModelRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAiModelResponse(request.CorrelationId());

            var aiModel = await _aiModelReadRepository.GetByIdAsync(request.AiModelId);

            if (aiModel == null)
            {
                return NotFound();
            }


            var aiModelDeletedEvent = new AiModelDeletedEvent(aiModel, "Mongo-History");
            _messagePublisher.Publish(aiModelDeletedEvent);

            await _repository.DeleteAsync(aiModel);

            return Ok(response);
        }
    }
}