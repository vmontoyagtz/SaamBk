using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Notification
{
    public class GetByIdNotificationResponse : BaseResponse
    {
        public GetByIdNotificationResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdNotificationResponse()
        {
        }

        public NotificationDto Notification { get; set; } = new();
    }
}