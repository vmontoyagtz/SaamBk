using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AiMemory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiMemoryEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAiMemoryRequest>.WithActionResult<
        CreateAiMemoryResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AiMemory> _repository;

        public Create(
            IRepository<AiMemory> repository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
        }

        [HttpPost("api/aiMemories")]
        [SwaggerOperation(
            Summary = "Creates a new AiMemory",
            Description = "Creates a new AiMemory",
            OperationId = "aiMemories.create",
            Tags = new[] { "AiMemoryEndpoints" })
        ]
        public override async Task<ActionResult<CreateAiMemoryResponse>> HandleAsync(
            CreateAiMemoryRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAiMemoryResponse(request.CorrelationId());


            var newAiMemory = new AiMemory(
                Guid.NewGuid(),
                request.ModelId,
                request.Question,
                request.Response,
                request.InteractionTime,
                request.TenantId
            );


            await _repository.AddAsync(newAiMemory);

            _logger.LogInformation(
                $"AiMemory created  with Id {newAiMemory.AiMemoryId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AiMemoryDto>(newAiMemory);

            var aiMemoryCreatedEvent = new AiMemoryCreatedEvent(newAiMemory, "Mongo-History");
            _messagePublisher.Publish(aiMemoryCreatedEvent);

            response.AiMemory = dto;


            return Ok(response);
        }
    }
}