using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Notification;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.NotificationEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteNotificationRequest>.WithActionResult<
        DeleteNotificationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Notification> _notificationReadRepository;
        private readonly IRepository<Notification> _repository;

        public Delete(IRepository<Notification> NotificationRepository,
            IRepository<Notification> NotificationReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = NotificationRepository;
            _notificationReadRepository = NotificationReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/notifications/{NotificationId}")]
        [SwaggerOperation(
            Summary = "Deletes an Notification",
            Description = "Deletes an Notification",
            OperationId = "notifications.delete",
            Tags = new[] { "NotificationEndpoints" })
        ]
        public override async Task<ActionResult<DeleteNotificationResponse>> HandleAsync(
            [FromRoute] DeleteNotificationRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteNotificationResponse(request.CorrelationId());

            var notification = await _notificationReadRepository.GetByIdAsync(request.NotificationId);

            if (notification == null)
            {
                return NotFound();
            }


            var notificationDeletedEvent = new NotificationDeletedEvent(notification, "Mongo-History");
            _messagePublisher.Publish(notificationDeletedEvent);

            await _repository.DeleteAsync(notification);

            return Ok(response);
        }
    }
}