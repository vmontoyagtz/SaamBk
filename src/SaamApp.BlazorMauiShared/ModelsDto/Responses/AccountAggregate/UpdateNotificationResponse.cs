using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Notification
{
    public class UpdateNotificationResponse : BaseResponse
    {
        public UpdateNotificationResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateNotificationResponse()
        {
        }

        public NotificationDto Notification { get; set; } = new();
    }
}