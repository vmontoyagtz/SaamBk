using System;

namespace SaamApp.BlazorMauiShared.Models.UserSession
{
    public class CreateUserSessionRequest : BaseRequest
    {
        public Guid ApplicationUserId { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }
        public Guid TenantId { get; set; }
    }
}