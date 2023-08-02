using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.MessageType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.MessageTypeEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateMessageTypeRequest>.WithActionResult<
        CreateMessageTypeResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<MessageType> _repository;

        public Create(
            IRepository<MessageType> repository,
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

        [HttpPost("api/messageTypes")]
        [SwaggerOperation(
            Summary = "Creates a new MessageType",
            Description = "Creates a new MessageType",
            OperationId = "messageTypes.create",
            Tags = new[] { "MessageTypeEndpoints" })
        ]
        public override async Task<ActionResult<CreateMessageTypeResponse>> HandleAsync(
            CreateMessageTypeRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateMessageTypeResponse(request.CorrelationId());


            var newMessageType = new MessageType(
                Guid.NewGuid(),
                request.MessageTypeName,
                request.MessageTypeDescription
            );


            await _repository.AddAsync(newMessageType);

            _logger.LogInformation(
                $"MessageType created  with Id {newMessageType.MessageTypeId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<MessageTypeDto>(newMessageType);

            var messageTypeCreatedEvent = new MessageTypeCreatedEvent(newMessageType, "Mongo-History");
            _messagePublisher.Publish(messageTypeCreatedEvent);

            response.MessageType = dto;


            return Ok(response);
        }
    }
}