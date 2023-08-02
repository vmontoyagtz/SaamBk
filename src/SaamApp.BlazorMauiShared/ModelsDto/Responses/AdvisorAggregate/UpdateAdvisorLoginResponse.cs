using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorLogin
{
    public class UpdateAdvisorLoginResponse : BaseResponse
    {
        public UpdateAdvisorLoginResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAdvisorLoginResponse()
        {
        }

        public AdvisorLoginDto AdvisorLogin { get; set; } = new();
    }
}