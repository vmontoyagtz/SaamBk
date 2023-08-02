using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AiErrorLog;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiErrorLogEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAiErrorLogRequest>.WithActionResult<
        CreateAiErrorLogResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AiErrorLog> _repository;

        public Create(
            IRepository<AiErrorLog> repository,
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

        [HttpPost("api/aiErrorLogs")]
        [SwaggerOperation(
            Summary = "Creates a new AiErrorLog",
            Description = "Creates a new AiErrorLog",
            OperationId = "aiErrorLogs.create",
            Tags = new[] { "AiErrorLogEndpoints" })
        ]
        public override async Task<ActionResult<CreateAiErrorLogResponse>> HandleAsync(
            CreateAiErrorLogRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAiErrorLogResponse(request.CorrelationId());


            var newAiErrorLog = new AiErrorLog(
                Guid.NewGuid(),
                request.ModelId,
                request.ErrorTime,
                request.ErrorMessage,
                request.TenantId
            );


            await _repository.AddAsync(newAiErrorLog);

            _logger.LogInformation(
                $"AiErrorLog created  with Id {newAiErrorLog.AiErrorLogId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AiErrorLogDto>(newAiErrorLog);

            var aiErrorLogCreatedEvent = new AiErrorLogCreatedEvent(newAiErrorLog, "Mongo-History");
            _messagePublisher.Publish(aiErrorLogCreatedEvent);

            response.AiErrorLog = dto;


            return Ok(response);
        }
    }
}