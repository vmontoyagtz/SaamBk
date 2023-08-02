using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Notification
{
    public class ListNotificationResponse : BaseResponse
    {
        public ListNotificationResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListNotificationResponse()
        {
        }

        public List<NotificationDto> Notifications { get; set; } = new();

        public int Count { get; set; }
    }
}