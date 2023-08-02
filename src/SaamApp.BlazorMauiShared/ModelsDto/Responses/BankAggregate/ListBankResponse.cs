using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Bank
{
    public class ListBankResponse : BaseResponse
    {
        public ListBankResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListBankResponse()
        {
        }

        public List<BankDto> Banks { get; set; } = new();

        public int Count { get; set; }
    }
}