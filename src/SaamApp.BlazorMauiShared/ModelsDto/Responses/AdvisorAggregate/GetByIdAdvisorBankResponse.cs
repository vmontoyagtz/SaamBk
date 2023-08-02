using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorBank
{
    public class GetByIdAdvisorBankResponse : BaseResponse
    {
        public GetByIdAdvisorBankResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAdvisorBankResponse()
        {
        }

        public AdvisorBankDto AdvisorBank { get; set; } = new();
    }
}