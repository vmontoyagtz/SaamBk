namespace SaamApp.BlazorMauiShared.Models.MessageType
{
    public class CreateMessageTypeRequest : BaseRequest
    {
        public string MessageTypeName { get; set; }
        public string? MessageTypeDescription { get; set; }
    }
}