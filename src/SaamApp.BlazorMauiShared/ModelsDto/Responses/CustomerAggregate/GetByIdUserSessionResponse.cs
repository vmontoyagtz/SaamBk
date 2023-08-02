using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.UserSession
{
    public class GetByIdUserSessionResponse : BaseResponse
    {
        public GetByIdUserSessionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdUserSessionResponse()
        {
        }

        public UserSessionDto UserSession { get; set; } = new();
    }
}