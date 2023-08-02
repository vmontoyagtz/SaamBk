using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.InteractionType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.InteractionTypeEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateInteractionTypeRequest>.WithActionResult<
        CreateInteractionTypeResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<InteractionType> _repository;

        public Create(
            IRepository<InteractionType> repository,
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

        [HttpPost("api/interactionTypes")]
        [SwaggerOperation(
            Summary = "Creates a new InteractionType",
            Description = "Creates a new InteractionType",
            OperationId = "interactionTypes.create",
            Tags = new[] { "InteractionTypeEndpoints" })
        ]
        public override async Task<ActionResult<CreateInteractionTypeResponse>> HandleAsync(
            CreateInteractionTypeRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateInteractionTypeResponse(request.CorrelationId());


            var newInteractionType = new InteractionType(
                Guid.NewGuid(),
                request.InteractionTypeName,
                request.InteractionDescription,
                request.TenantId
            );


            await _repository.AddAsync(newInteractionType);

            _logger.LogInformation(
                $"InteractionType created  with Id {newInteractionType.InteractionTypeId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<InteractionTypeDto>(newInteractionType);

            var interactionTypeCreatedEvent = new InteractionTypeCreatedEvent(newInteractionType, "Mongo-History");
            _messagePublisher.Publish(interactionTypeCreatedEvent);

            response.InteractionType = dto;


            return Ok(response);
        }
    }
}