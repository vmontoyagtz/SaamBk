using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AiModel;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiModelEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAiModelRequest>.WithActionResult<
        CreateAiModelResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AiModel> _repository;

        public Create(
            IRepository<AiModel> repository,
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

        [HttpPost("api/aiModels")]
        [SwaggerOperation(
            Summary = "Creates a new AiModel",
            Description = "Creates a new AiModel",
            OperationId = "aiModels.create",
            Tags = new[] { "AiModelEndpoints" })
        ]
        public override async Task<ActionResult<CreateAiModelResponse>> HandleAsync(
            CreateAiModelRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAiModelResponse(request.CorrelationId());


            var newAiModel = new AiModel(
                Guid.NewGuid(),
                request.ModelName,
                request.ModelDescription,
                request.TrainingData,
                request.TrainingDate,
                request.Accuracy,
                request.IsActive,
                request.TenantId
            );


            await _repository.AddAsync(newAiModel);

            _logger.LogInformation(
                $"AiModel created  with Id {newAiModel.AiModelId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AiModelDto>(newAiModel);

            var aiModelCreatedEvent = new AiModelCreatedEvent(newAiModel, "Mongo-History");
            _messagePublisher.Publish(aiModelCreatedEvent);

            response.AiModel = dto;


            return Ok(response);
        }
    }
}