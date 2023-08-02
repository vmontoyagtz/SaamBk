using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.UserSession
{
    public class ListUserSessionResponse : BaseResponse
    {
        public ListUserSessionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListUserSessionResponse()
        {
        }

        public List<UserSessionDto> UserSessions { get; set; } = new();

        public int Count { get; set; }
    }
}