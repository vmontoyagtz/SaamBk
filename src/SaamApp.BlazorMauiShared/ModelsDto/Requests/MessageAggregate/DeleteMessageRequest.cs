using System;

namespace SaamApp.BlazorMauiShared.Models.Message
{
    public class DeleteMessageRequest : BaseRequest
    {
        public Guid MessageId { get; set; }
    }
}