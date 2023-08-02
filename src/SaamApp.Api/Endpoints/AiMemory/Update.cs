using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiMemory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AiMemoryEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAiMemoryRequest>.WithActionResult<UpdateAiMemoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AiMemory> _repository;

        public Update(
            IRepository<AiMemory> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/aiMemories")]
        [SwaggerOperation(
            Summary = "Updates a AiMemory",
            Description = "Updates a AiMemory",
            OperationId = "aiMemories.update",
            Tags = new[] { "AiMemoryEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAiMemoryResponse>> HandleAsync(UpdateAiMemoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateAiMemoryResponse(request.CorrelationId());

            var amimmToUpdate = _mapper.Map<AiMemory>(request);

            var aiMemoryToUpdateTest = await _repository.GetByIdAsync(request.AiMemoryId);
            if (aiMemoryToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(amimmToUpdate);

            var aiMemoryUpdatedEvent = new AiMemoryUpdatedEvent(amimmToUpdate, "Mongo-History");
            _messagePublisher.Publish(aiMemoryUpdatedEvent);

            var dto = _mapper.Map<AiMemoryDto>(amimmToUpdate);
            response.AiMemory = dto;

            return Ok(response);
        }
    }
}