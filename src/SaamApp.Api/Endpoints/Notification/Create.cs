using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.Notification;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.NotificationEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateNotificationRequest>.WithActionResult<
        CreateNotificationResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Notification> _repository;

        public Create(
            IRepository<Notification> repository,
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

        [HttpPost("api/notifications")]
        [SwaggerOperation(
            Summary = "Creates a new Notification",
            Description = "Creates a new Notification",
            OperationId = "notifications.create",
            Tags = new[] { "NotificationEndpoints" })
        ]
        public override async Task<ActionResult<CreateNotificationResponse>> HandleAsync(
            CreateNotificationRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateNotificationResponse(request.CorrelationId());


            var newNotification = new Notification(
                Guid.NewGuid(),
                request.ApplicationUserId,
                request.NotificationText,
                request.IsRead,
                request.NotificationTime,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted,
                request.TenantId
            );


            await _repository.AddAsync(newNotification);

            _logger.LogInformation(
                $"Notification created  with Id {newNotification.NotificationId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<NotificationDto>(newNotification);

            var notificationCreatedEvent = new NotificationCreatedEvent(newNotification, "Mongo-History");
            _messagePublisher.Publish(notificationCreatedEvent);

            response.Notification = dto;


            return Ok(response);
        }
    }
}