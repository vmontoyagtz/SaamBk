using System;

namespace SaamApp.BlazorMauiShared.Models.UserSession
{
    public class DeleteUserSessionRequest : BaseRequest
    {
        public Guid SessionId { get; set; }
    }
}