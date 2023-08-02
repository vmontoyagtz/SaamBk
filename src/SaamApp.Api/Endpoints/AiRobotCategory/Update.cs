using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiRobotCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AiRobotCategoryEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAiRobotCategoryRequest>.WithActionResult<
        UpdateAiRobotCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AiRobotCategory> _repository;

        public Update(
            IRepository<AiRobotCategory> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/aiRobotCategories")]
        [SwaggerOperation(
            Summary = "Updates a AiRobotCategory",
            Description = "Updates a AiRobotCategory",
            OperationId = "aiRobotCategories.update",
            Tags = new[] { "AiRobotCategoryEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAiRobotCategoryResponse>> HandleAsync(
            UpdateAiRobotCategoryRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateAiRobotCategoryResponse(request.CorrelationId());

            var arcircrcToUpdate = _mapper.Map<AiRobotCategory>(request);

            var aiRobotCategoryToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (aiRobotCategoryToUpdateTest is null)
            {
                return NotFound();
            }

            arcircrcToUpdate.UpdateRegionAreaAdvisorCategoryForAiRobotCategory(request.RegionAreaAdvisorCategoryId);
            arcircrcToUpdate.UpdateComissionForAiRobotCategory(request.ComissionId);
            arcircrcToUpdate.UpdateAiRobotForAiRobotCategory(request.AiRobotId);
            await _repository.UpdateAsync(arcircrcToUpdate);

            var aiRobotCategoryUpdatedEvent = new AiRobotCategoryUpdatedEvent(arcircrcToUpdate, "Mongo-History");
            _messagePublisher.Publish(aiRobotCategoryUpdatedEvent);

            var dto = _mapper.Map<AiRobotCategoryDto>(arcircrcToUpdate);
            response.AiRobotCategory = dto;

            return Ok(response);
        }
    }
}