using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AiSession;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiSessionEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAiSessionRequest>.WithActionResult<
        CreateAiSessionResponse>
    {
        private readonly IRepository<Customer> _customerRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AiSession> _repository;

        public Create(
            IRepository<AiSession> repository,
            IRepository<Customer> customerRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _customerRepository = customerRepository;
        }

        [HttpPost("api/aiSessions")]
        [SwaggerOperation(
            Summary = "Creates a new AiSession",
            Description = "Creates a new AiSession",
            OperationId = "aiSessions.create",
            Tags = new[] { "AiSessionEndpoints" })
        ]
        public override async Task<ActionResult<CreateAiSessionResponse>> HandleAsync(
            CreateAiSessionRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAiSessionResponse(request.CorrelationId());

            //var customer = await _customerRepository.GetByIdAsync(request.CustomerId);// parent entity

            var newAiSession = new AiSession(
                Guid.NewGuid(),
                request.CustomerId,
                request.StartTime,
                request.EndTime,
                request.NumberOfInteractions
            );


            await _repository.AddAsync(newAiSession);

            _logger.LogInformation(
                $"AiSession created  with Id {newAiSession.AiSessionId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AiSessionDto>(newAiSession);

            var aiSessionCreatedEvent = new AiSessionCreatedEvent(newAiSession, "Mongo-History");
            _messagePublisher.Publish(aiSessionCreatedEvent);

            response.AiSession = dto;


            return Ok(response);
        }
    }
}