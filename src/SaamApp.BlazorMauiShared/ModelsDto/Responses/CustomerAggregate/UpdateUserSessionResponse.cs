using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.UserSession
{
    public class UpdateUserSessionResponse : BaseResponse
    {
        public UpdateUserSessionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateUserSessionResponse()
        {
        }

        public UserSessionDto UserSession { get; set; } = new();
    }
}