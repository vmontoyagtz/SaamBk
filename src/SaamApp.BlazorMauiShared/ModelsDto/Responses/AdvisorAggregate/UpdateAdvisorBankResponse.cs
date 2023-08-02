using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorBank
{
    public class UpdateAdvisorBankResponse : BaseResponse
    {
        public UpdateAdvisorBankResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAdvisorBankResponse()
        {
        }

        public AdvisorBankDto AdvisorBank { get; set; } = new();
    }
}