using System;

namespace SaamApp.BlazorMauiShared.Models.Message
{
    public class GetByIdMessageRequest : BaseRequest
    {
        public Guid MessageId { get; set; }
    }
}