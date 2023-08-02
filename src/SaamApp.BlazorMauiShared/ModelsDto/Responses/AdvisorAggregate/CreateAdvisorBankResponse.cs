using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorBank
{
    public class CreateAdvisorBankResponse : BaseResponse
    {
        public CreateAdvisorBankResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAdvisorBankResponse()
        {
        }

        public AdvisorBankDto AdvisorBank { get; set; } = new();
    }
}