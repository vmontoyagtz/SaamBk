using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorLogin
{
    public class CreateAdvisorLoginResponse : BaseResponse
    {
        public CreateAdvisorLoginResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAdvisorLoginResponse()
        {
        }

        public AdvisorLoginDto AdvisorLogin { get; set; } = new();
    }
}