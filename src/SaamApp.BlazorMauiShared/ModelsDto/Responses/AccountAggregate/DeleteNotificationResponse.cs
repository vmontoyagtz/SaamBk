using System;

namespace SaamApp.BlazorMauiShared.Models.Notification
{
    public class DeleteNotificationResponse : BaseResponse
    {
        public DeleteNotificationResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteNotificationResponse()
        {
        }
    }
}