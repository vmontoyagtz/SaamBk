using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiMemory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiMemoryEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAiMemoryRequest>.WithActionResult<
        DeleteAiMemoryResponse>
    {
        private readonly IRepository<AiMemory> _aiMemoryReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AiMemory> _repository;

        public Delete(IRepository<AiMemory> AiMemoryRepository, IRepository<AiMemory> AiMemoryReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AiMemoryRepository;
            _aiMemoryReadRepository = AiMemoryReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/aiMemories/{AiMemoryId}")]
        [SwaggerOperation(
            Summary = "Deletes an AiMemory",
            Description = "Deletes an AiMemory",
            OperationId = "aiMemories.delete",
            Tags = new[] { "AiMemoryEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAiMemoryResponse>> HandleAsync(
            [FromRoute] DeleteAiMemoryRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAiMemoryResponse(request.CorrelationId());

            var aiMemory = await _aiMemoryReadRepository.GetByIdAsync(request.AiMemoryId);

            if (aiMemory == null)
            {
                return NotFound();
            }


            var aiMemoryDeletedEvent = new AiMemoryDeletedEvent(aiMemory, "Mongo-History");
            _messagePublisher.Publish(aiMemoryDeletedEvent);

            await _repository.DeleteAsync(aiMemory);

            return Ok(response);
        }
    }
}