using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Notification;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.NotificationEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdNotificationRequest>.WithActionResult<
        GetByIdNotificationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Notification> _repository;

        public GetById(
            IRepository<Notification> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/notifications/{NotificationId}")]
        [SwaggerOperation(
            Summary = "Get a Notification by Id",
            Description = "Gets a Notification by Id",
            OperationId = "notifications.GetById",
            Tags = new[] { "NotificationEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdNotificationResponse>> HandleAsync(
            [FromRoute] GetByIdNotificationRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdNotificationResponse(request.CorrelationId());

            var notification = await _repository.GetByIdAsync(request.NotificationId);
            if (notification is null)
            {
                return NotFound();
            }

            response.Notification = _mapper.Map<NotificationDto>(notification);

            return Ok(response);
        }
    }
}