using System;

namespace SaamApp.BlazorMauiShared.Models.UserSession
{
    public class GetByIdUserSessionRequest : BaseRequest
    {
        public Guid SessionId { get; set; }
    }
}