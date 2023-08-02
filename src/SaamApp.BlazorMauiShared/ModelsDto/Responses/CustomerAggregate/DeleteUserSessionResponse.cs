using System;

namespace SaamApp.BlazorMauiShared.Models.UserSession
{
    public class DeleteUserSessionResponse : BaseResponse
    {
        public DeleteUserSessionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteUserSessionResponse()
        {
        }
    }
}