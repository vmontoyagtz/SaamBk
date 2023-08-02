using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiModel;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AiModelEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAiModelRequest>.WithActionResult<UpdateAiModelResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AiModel> _repository;

        public Update(
            IRepository<AiModel> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/aiModels")]
        [SwaggerOperation(
            Summary = "Updates a AiModel",
            Description = "Updates a AiModel",
            OperationId = "aiModels.update",
            Tags = new[] { "AiModelEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAiModelResponse>> HandleAsync(UpdateAiModelRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateAiModelResponse(request.CorrelationId());

            var amimmToUpdate = _mapper.Map<AiModel>(request);

            var aiModelToUpdateTest = await _repository.GetByIdAsync(request.AiModelId);
            if (aiModelToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(amimmToUpdate);

            var aiModelUpdatedEvent = new AiModelUpdatedEvent(amimmToUpdate, "Mongo-History");
            _messagePublisher.Publish(aiModelUpdatedEvent);

            var dto = _mapper.Map<AiModelDto>(amimmToUpdate);
            response.AiModel = dto;

            return Ok(response);
        }
    }
}