using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorBank
{
    public class ListAdvisorBankResponse : BaseResponse
    {
        public ListAdvisorBankResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAdvisorBankResponse()
        {
        }

        public List<AdvisorBankDto> AdvisorBanks { get; set; } = new();

        public int Count { get; set; }
    }
}