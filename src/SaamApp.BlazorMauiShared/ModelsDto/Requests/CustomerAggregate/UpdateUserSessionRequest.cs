using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.UserSession
{
    public class UpdateUserSessionRequest : BaseRequest
    {
        public Guid SessionId { get; set; }
        public Guid ApplicationUserId { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateUserSessionRequest FromDto(UserSessionDto userSessionDto)
        {
            return new UpdateUserSessionRequest
            {
                SessionId = userSessionDto.SessionId,
                ApplicationUserId = userSessionDto.ApplicationUserId,
                LoginTime = userSessionDto.LoginTime,
                LogoutTime = userSessionDto.LogoutTime,
                TenantId = userSessionDto.TenantId
            };
        }
    }
}