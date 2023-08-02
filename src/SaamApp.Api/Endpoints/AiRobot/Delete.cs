using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiRobot;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiRobotEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAiRobotRequest>.WithActionResult<
        DeleteAiRobotResponse>
    {
        private readonly IRepository<AiInteraction> _aiInteractionRepository;
        private readonly IRepository<AiRobotCategory> _aiRobotCategoryRepository;
        private readonly IRepository<AiRobot> _aiRobotReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AiRobot> _repository;

        public Delete(IRepository<AiRobot> AiRobotRepository, IRepository<AiRobot> AiRobotReadRepository,
            IRepository<AiInteraction> aiInteractionRepository,
            IRepository<AiRobotCategory> aiRobotCategoryRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AiRobotRepository;
            _aiRobotReadRepository = AiRobotReadRepository;
            _aiInteractionRepository = aiInteractionRepository;
            _aiRobotCategoryRepository = aiRobotCategoryRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/aiRobots/{AiRobotId}")]
        [SwaggerOperation(
            Summary = "Deletes an AiRobot",
            Description = "Deletes an AiRobot",
            OperationId = "aiRobots.delete",
            Tags = new[] { "AiRobotEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAiRobotResponse>> HandleAsync(
            [FromRoute] DeleteAiRobotRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAiRobotResponse(request.CorrelationId());

            var aiRobot = await _aiRobotReadRepository.GetByIdAsync(request.AiRobotId);

            if (aiRobot == null)
            {
                return NotFound();
            }

            var aiInteractionSpec = new GetAiInteractionWithAiRobotKeySpec(aiRobot.AiRobotId);
            var aiInteractions = await _aiInteractionRepository.ListAsync(aiInteractionSpec);
            await _aiInteractionRepository
                .DeleteRangeAsync(aiInteractions); // you could use soft delete with IsDeleted = true
            var aiRobotCategorySpec = new GetAiRobotCategoryWithAiRobotKeySpec(aiRobot.AiRobotId);
            var aiRobotCategories = await _aiRobotCategoryRepository.ListAsync(aiRobotCategorySpec);
            await _aiRobotCategoryRepository.DeleteRangeAsync(aiRobotCategories);

            var aiRobotDeletedEvent = new AiRobotDeletedEvent(aiRobot, "Mongo-History");
            _messagePublisher.Publish(aiRobotDeletedEvent);

            await _repository.DeleteAsync(aiRobot);

            return Ok(response);
        }
    }
}