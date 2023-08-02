using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.UserSession
{
    public class CreateUserSessionResponse : BaseResponse
    {
        public CreateUserSessionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateUserSessionResponse()
        {
        }

        public UserSessionDto UserSession { get; set; } = new();
    }
}