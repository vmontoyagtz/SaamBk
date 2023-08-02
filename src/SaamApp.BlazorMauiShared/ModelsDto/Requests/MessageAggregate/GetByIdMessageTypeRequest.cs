using System;

namespace SaamApp.BlazorMauiShared.Models.MessageType
{
    public class GetByIdMessageTypeRequest : BaseRequest
    {
        public Guid MessageTypeId { get; set; }
    }
}