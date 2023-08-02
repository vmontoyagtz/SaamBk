using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorLogin
{
    public class GetByIdAdvisorLoginResponse : BaseResponse
    {
        public GetByIdAdvisorLoginResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAdvisorLoginResponse()
        {
        }

        public AdvisorLoginDto AdvisorLogin { get; set; } = new();
    }
}