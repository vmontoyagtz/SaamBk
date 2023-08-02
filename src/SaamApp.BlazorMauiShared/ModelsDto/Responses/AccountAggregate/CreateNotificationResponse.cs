using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Notification
{
    public class CreateNotificationResponse : BaseResponse
    {
        public CreateNotificationResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateNotificationResponse()
        {
        }

        public NotificationDto Notification { get; set; } = new();
    }
}