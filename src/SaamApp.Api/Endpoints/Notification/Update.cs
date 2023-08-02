using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Notification;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.NotificationEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateNotificationRequest>.WithActionResult<
        UpdateNotificationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Notification> _repository;

        public Update(
            IRepository<Notification> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/notifications")]
        [SwaggerOperation(
            Summary = "Updates a Notification",
            Description = "Updates a Notification",
            OperationId = "notifications.update",
            Tags = new[] { "NotificationEndpoints" })
        ]
        public override async Task<ActionResult<UpdateNotificationResponse>> HandleAsync(
            UpdateNotificationRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateNotificationResponse(request.CorrelationId());

            var notToUpdate = _mapper.Map<Notification>(request);

            var notificationToUpdateTest = await _repository.GetByIdAsync(request.NotificationId);
            if (notificationToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(notToUpdate);

            var notificationUpdatedEvent = new NotificationUpdatedEvent(notToUpdate, "Mongo-History");
            _messagePublisher.Publish(notificationUpdatedEvent);

            var dto = _mapper.Map<NotificationDto>(notToUpdate);
            response.Notification = dto;

            return Ok(response);
        }
    }
}