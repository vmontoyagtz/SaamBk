using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Notification;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.NotificationEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListNotificationRequest>.WithActionResult<
        ListNotificationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Notification> _repository;

        public List(IRepository<Notification> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/notifications")]
        [SwaggerOperation(
            Summary = "List Notifications",
            Description = "List Notifications",
            OperationId = "notifications.List",
            Tags = new[] { "NotificationEndpoints" })
        ]
        public override async Task<ActionResult<ListNotificationResponse>> HandleAsync(
            [FromQuery] ListNotificationRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListNotificationResponse(request.CorrelationId());

            var spec = new NotificationGetListSpec();
            var notifications = await _repository.ListAsync(spec);
            if (notifications is null)
            {
                return NotFound();
            }

            response.Notifications = _mapper.Map<List<NotificationDto>>(notifications);
            response.Count = response.Notifications.Count;

            return Ok(response);
        }
    }
}