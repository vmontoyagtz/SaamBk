using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiRobotCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiRobotCategoryEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAiRobotCategoryRequest>.WithActionResult<
        DeleteAiRobotCategoryResponse>
    {
        private readonly IRepository<AiRobotCategory> _aiRobotCategoryReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AiRobotCategory> _repository;

        public Delete(IRepository<AiRobotCategory> AiRobotCategoryRepository,
            IRepository<AiRobotCategory> AiRobotCategoryReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AiRobotCategoryRepository;
            _aiRobotCategoryReadRepository = AiRobotCategoryReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/aiRobotCategories/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an AiRobotCategory",
            Description = "Deletes an AiRobotCategory",
            OperationId = "aiRobotCategories.delete",
            Tags = new[] { "AiRobotCategoryEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAiRobotCategoryResponse>> HandleAsync(
            [FromRoute] DeleteAiRobotCategoryRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAiRobotCategoryResponse(request.CorrelationId());

            var aiRobotCategory = await _aiRobotCategoryReadRepository.GetByIdAsync(request.RowId);

            if (aiRobotCategory == null)
            {
                return NotFound();
            }


            var aiRobotCategoryDeletedEvent = new AiRobotCategoryDeletedEvent(aiRobotCategory, "Mongo-History");
            _messagePublisher.Publish(aiRobotCategoryDeletedEvent);

            await _repository.DeleteAsync(aiRobotCategory);

            return Ok(response);
        }
    }
}