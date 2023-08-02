using System;

namespace SaamApp.BlazorMauiShared.Models.MessageType
{
    public class DeleteMessageTypeRequest : BaseRequest
    {
        public Guid MessageTypeId { get; set; }
    }
}